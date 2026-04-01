using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1PD25
{
    internal class Program
    {

        delegate string MyDelegate(string text);

        static string ToUpperCase(string text)
        {
            return text.ToUpper();
        }

        static string CountChars(string text)
        {
            return $"Char: {text.Length}";
        }

        static string CountWords(string text)
        {
            var words = text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return $"Words: {words.Length}";
        }

        static void ProccesFile(string inputPath, string outputPath, MyDelegate operation)
        {
            using (FileStream fsRead = new FileStream(inputPath, FileMode.Open))
            using (StreamReader sr = new StreamReader(fsRead))
            using (FileStream fsWrite = new FileStream(outputPath, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fsWrite))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string result = operation(line);
                    sw.WriteLine(result);
                }
                sw.WriteLine("--------");
            }

        }

        static void Main()
        {
            string inputPath = "C:\\Users\\stud\\source\\repos\\Modul1PD25\\Modul1PD25\\obj\\Debug\\textPD25.txt";
            string outputPath = "C:\\Users\\stud\\source\\repos\\Modul1PD25\\Modul1PD25\\obj\\Debug\\resultPD25.txt";

            ProccesFile(inputPath, outputPath, ToUpperCase);
            ProccesFile(inputPath, outputPath, CountChars);
            ProccesFile(inputPath, outputPath, CountWords);
        }
    }
}
