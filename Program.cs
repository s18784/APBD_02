using APBD_02.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace APBD_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = args.Length > 0 ? args[0] : @"Files\dane.csv";
            var outputPath = args.Length == 3 ? args[0] : @"Files\result.xml";
            var dataType= args.Length == 3 ? args[0] : "xml";

            var university = new Uczelnia();
            //Console.WriteLine($"{arg1} {arg2} {arg3}");
            try
            {

                if (!File.Exists(inputPath)) throw new FileNotFoundException("ERR", inputPath.Split("\\")[^1]); 

            var contents = File.ReadAllLines(inputPath);
                var list = new List<Student>();

                foreach (var line in contents)
                {
                    //Console.WriteLine(line);
                    File.AppendAllText(outputPath, line);
                    var splitted = line.Split(",");
                    if (splitted.Length == 9)
                    {
                        var student = new Student
                        {
                            Imie = splitted[0],
                            Nazwisko = splitted[1],
                            Email = splitted[6]
                        };
                        list.Add(student);
                    }
                }

                using var writer = new FileStream($"{outputPath}", FileMode.Create);
                var serializer = new XmlSerializer(typeof(Uczelnia));
                serializer.Serialize(writer, list);
            }
            catch(FileNotFoundException e)
            {
                File.AppendAllText("log.txt", $"{DateTime.UtcNow} {e.Message} {e.FileName}");
            }
        }
    }
}
