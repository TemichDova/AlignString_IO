using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;


namespace AlignString_IO 
{
    using static AlignString_IO.OperationOnFiles;
    class Program 
    {
        static OperationOnFiles operationOnFiles = new OperationOnFiles();
 
        static void Main(string[] args)
        {
 
            if (args.Length == 0)
            {

            }
            else
            {
              
                string typeFile;
               
                for (int i = 0; i < args.Length; i++)
                {
                    typeFile = args[i];
                    if (typeFile == "/I" || typeFile == "/i")
                    {
                        operationOnFiles.SelectPathInputFile(args[i+1]);
                    }

                    if (typeFile == "/O" || typeFile == "/o")
                    {
                        operationOnFiles.SelectPathOutFile(args[i+1]);
                    }
                }

            }


            Console.WriteLine("Начало работы программы");
            
            if (operationOnFiles.PathInputFile == null || operationOnFiles.PathInputFile == "" || operationOnFiles.PathInputFile == " ")
            {
                Console.WriteLine("Входящий файл по умолчанию не задан, введите существующий путь");
                
                do
                {
                    
                    operationOnFiles.SelectPathInputFile(Console.ReadLine());
                    
                } while (!operationOnFiles.SearchPathFile(operationOnFiles.PathInputFile,false));
            }

            if (operationOnFiles.PathOutFile == null || operationOnFiles.PathOutFile == "" || operationOnFiles.PathOutFile == " ")
            {
                Console.WriteLine("Выходящий файл по умолчанию не задан, введите существующий путь");
                do
                {
                    operationOnFiles.SelectPathOutFile(Console.ReadLine());
                } while (!operationOnFiles.SearchPathFile(operationOnFiles.PathOutFile,false));
            }

            operationOnFiles.InteractiveConsoleInputFile();
            
            Console.WriteLine("Дополнить входящий файл через консоль?: Yes(Y) No(N)");
            if (operationOnFiles.CheckWriteOption())
            {
                Console.WriteLine("Для окончание введите с новой строки .end");
                operationOnFiles.NewWriteFileConsole(operationOnFiles.PathInputFile);
            }
            else
            {
                Console.WriteLine("Открыть входящий файл?: Yes(Y) No(N)");
                if (operationOnFiles.CheckWriteOption())
                {
                    operationOnFiles.OpenFile(operationOnFiles.PathInputFile);
                }
            }

            operationOnFiles.InteractiveConsoleOutFile();
            
            Console.WriteLine("\nНачало процедуры");
            Console.WriteLine("------------------------------");
            
            AlignTextInFile(operationOnFiles.PathInputFile,operationOnFiles.PathOutFile,SelectAlignTextConsole());
            
            Console.WriteLine("------------------------------");
            Console.WriteLine("Процедура выполнена");

            Console.WriteLine("\nОткрыть выходящий файл?: Yes(Y) No(N)");

            if (operationOnFiles.CheckWriteOption())
            {
                operationOnFiles.OpenFile(operationOnFiles.PathOutFile);
            }
            Console.ReadLine();
        }
              
        static int SelectAlignTextConsole()
        {
            int indexSelectionAlignText = -1;
            
            Console.WriteLine("Выберите метод выравнивание текста: \nПо левому краю - 1 \nПо правому краю - 2 \nПо центру - 3");
                        
            while (!Int32.TryParse(Console.ReadLine(), out indexSelectionAlignText) || indexSelectionAlignText > 3 || indexSelectionAlignText < 1  )
            {
                if ( 3>= indexSelectionAlignText && indexSelectionAlignText >=1)
                {
                    return indexSelectionAlignText;
                }
                else
                {
                    Console.WriteLine("Вы ввели не верное значение, введите заного");
                }
            }
            
            return indexSelectionAlignText;
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
                case 1:
                    return line.PadRight(line.Length);

                //Right Align
                case 2:
                    return line.PadLeft(width);

                //Center Align
                case 3:
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
