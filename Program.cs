using System;
using System.IO;

namespace APBD_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = args.Length > 0 ? args[0] : "Files/dane.csv";
            var outputPath = args.Length == 3 ? args[0] : "output";
            var dataType= args.Length == 3 ? args[0] : "xml";

            //Console.WriteLine($"{arg1} {arg2} {arg3}");

            var contents = File.ReadAllLines(inputPath);

            foreach(var line in contents)
            {
                Console.WriteLine(line);
            }
        }
    }
}
