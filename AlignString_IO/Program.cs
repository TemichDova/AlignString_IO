using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;


namespace AlignString_IO 
{
    class Program 
    {
        static WorkingTheFiles workingTheFile = new WorkingTheFiles();

        static void Main(string[] args)
        {
            // Путь к файлам
            string pathInFile = workingTheFile.PathToInFile;
            string pathOutFile = workingTheFile.PathToOutFile;
            pathInFile = @"in.txt";
            pathOutFile = @"out.txt";


            workingTheFile.InFileSearchPath(pathInFile);

            workingTheFile.OutFileSearchPath(pathOutFile);


            Console.WriteLine("\nНачало процедуры");
            Console.WriteLine("------------------------------");           
            SelectionAlignTextInFile(pathInFile, pathOutFile);

            Console.WriteLine("------------------------------");
            Console.WriteLine("Процедура выполнена");

            workingTheFile.OpenFile(pathOutFile);

            Console.ReadLine();
        }
        
        static void SelectionAlignTextInFile(string sourceFileName, string destinationFileName)
        {
            int indexSelectionAlignText = -1;
            Console.WriteLine("Выберите метод выравнивание текста: \nПо левому краю - 0 \nПо правому краю - 1 \nПо центру - 2");

            //Метка для goto
            Restart:
                if(indexSelectionAlignText != -1) Console.WriteLine("Вы ввели не верное значение, введите заного");
                        
            if (int.TryParse(Console.ReadLine(), out indexSelectionAlignText))
            {
                switch (indexSelectionAlignText)
                {
                    case 0:
                        Console.WriteLine("\nВыравниение по левому краю");
                        AlignTextInFile(sourceFileName, destinationFileName,indexSelectionAlignText);
                        break;

                    case 1:
                        Console.WriteLine("\nВыравниение по правому краю");
                        AlignTextInFile(sourceFileName, destinationFileName, indexSelectionAlignText);
                        break;

                    case 2:
                        Console.WriteLine("\nВыравниение по цетру");
                        AlignTextInFile(sourceFileName, destinationFileName, indexSelectionAlignText);
                        break;

                    default:
                        goto Restart;
                }
            }
            else
            {
                goto Restart;
            }

        }

        static void AlignTextInFile(string sourceFileName, string destinationFileName, int indexAlignText)
        {
            int maxWidthAlign = getMaxLineLenght(sourceFileName);
            string[] linesText = LinesTextInFile(sourceFileName);

            using (StreamWriter sw = new StreamWriter(destinationFileName, false, Encoding.Default))
            {
                for(int i= 0; i < linesText.Length; i++)
                {
                    if (linesText.Length - 1 != i)
                    {
                        sw.WriteLine(AligningToLine(linesText[i], maxWidthAlign,indexAlignText));
                    }
                    else
                    {
                        sw.Write(AligningToLine(linesText[i], maxWidthAlign,indexAlignText));
                    }
                }
            }
        }

        static int getMaxLineLenght(string fileName)
        {
            int countSkipChar = 0;
            
            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {
                string readLine;
                while ((readLine = sr.ReadLine()) != null)
                {
                    if (countSkipChar < readLine.Trim().Length ) countSkipChar = readLine.Length;
                                      
                }
            }
            return countSkipChar;
        }

        static string AligningToLine(string line, int width, int indexAlignText)
        {

            if (line == "")
            {
                return line;
            }
            

            switch (indexAlignText)
            {
                //Left Align
                case 0:
                    return line.PadRight(line.Length);

                //Right Align
                case 1:
                    return line.PadLeft(width);

                //Center Align
                case 2:
                    return line.PadLeft(width / 2 - line.Length / 2 + line.Length);
                default:
                    return line;
                                
            }
                        
        }
             

        static string[] LinesTextInFile(string fileName)
        {
            List<string> lineText = new List<string>();

            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {
                string readLine;
                while ((readLine = sr.ReadLine()) != null)
                {
                    lineText.Add(readLine.Trim());
                }
            }
            return lineText.ToArray();
        }

       
    }
}
