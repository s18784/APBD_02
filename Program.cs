using APBD_02.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace APBD_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = args.Length > 0 ? args[0] : @"Files\dane.csv";
            var outputPath = args.Length > 1 ? args[0] : @"Files\result.xml";
            var dataType= args.Length > 2 ? args[0] : "xml";

            var university = new Uczelnia();
            //Console.WriteLine($"{arg1} {arg2} {arg3}");
            try
            {

                if (!File.Exists(inputPath)) throw new FileNotFoundException("ERR", inputPath.Split("\\")[^1]);

                var contents = File.ReadAllLines(inputPath);
                var set = new HashSet<Student>();

                foreach (var line in contents)
                {
                    //Console.WriteLine(line);
                    File.AppendAllText(outputPath, line);
                    var splitted = line.Split(",");
                    if (splitted.Length == 9)
                    {
                        var studies = splitted[2].Split(" ");
                        var sb = new StringBuilder();
                        string type;
                        if(studies.Length == 4)
                        {
                            sb.Append(studies[0] + " " + studies[1] + " " + studies[2]);
                            type = studies[3];
                        } else
                        {
                            sb.Append(studies[0]);
                            type = studies[1];
                        }

                        var student = new Student
                        {
                            Imie = splitted[0],
                            Nazwisko = splitted[1],
                            DataUrodzin = splitted[5],
                            Email = splitted[6],
                            ImieMatki = splitted[7],
                            ImieOjca = splitted[8],
                            Studia = new StudiaInfo
                            {
                                Name = sb.ToString(),
                                Type = type,
                            },
                            Index = splitted[4],
                    };

                    set.Add(student);
                }
           
            }
                var uczelnie = new Uczelnia
                {
                    Students = set,
                    Author = "Mateusz Kadłubowski",
                };
                using var writer = new FileStream($"{outputPath}", FileMode.Create);
                var serializer = new XmlSerializer(typeof(Uczelnia));
                serializer.Serialize(writer, uczelnie);
            }
            catch(FileNotFoundException e)
            {
                File.AppendAllText("log.txt", $"{DateTime.UtcNow} {e.Message} {e.FileName}");
            }
        }
    }
}
