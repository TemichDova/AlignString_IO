using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace AlignString_IO
{
    class Program
    {
        static void Main(string[] args)
        {
            string skip = "";
            int skipSymbol = 0;
            List<string> outWords = new List<string>();

            // Путь к файлам
            string pathIn = @"..\..\..\in.txt";
            string pathOut = @"..\..\..\out.txt";

            StreamReader _pathIn = new StreamReader(pathIn, Encoding.Default);
            StreamWriter _pathOut = new StreamWriter(pathOut,false, Encoding.Default);

            // Чтение файла
            using ( StreamReader sr = _pathIn)
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if (skipSymbol < s.Length) skipSymbol = s.Length;
                    outWords.Add(s);
                }
            }

            //Количество пробелов
            for (int i = 0; i < skipSymbol; i++)
            {
                skip += " ";
            }
           
            // Запись в файл File.CreateText(pathOut)
            using (StreamWriter sw = _pathOut)
            {
                foreach(string n in outWords)
                {
                    sw.WriteLine(skip+n);
                }
            }
                Console.ReadLine();
        }
        
    }
}
