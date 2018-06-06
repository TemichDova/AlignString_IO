using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlignString_IO
{
    class OperationOnFiles
    {

        public string PathInputFile { get; set; } = "in.txt";
        public string PathOutFile { get; set; } = @"out.txt";

        public void SelectPathInputFile(string pathFile = @"in.txt", bool newFile = false)
        {
            
            PathInputFile = String.Format(@"{0}", pathFile);

            if (newFile)
            {
                NewPathInFile(PathInputFile);
            }
        }

        public void SelectPathOutFile(string pathFile = @"out.txt", bool newFile = false)
        {
            PathOutFile = String.Format(@"{0}", pathFile);

            if (newFile)
            {
                NewPathInFile(PathOutFile);
            }

        }

        public bool SearchPathFile(string pathFile)
        {
                        
            var fileInfo = new FileInfo(pathFile);

            if (File.Exists(pathFile))
            {
                Console.WriteLine("\nДоступен файл {0}", fileInfo.Name);
                return true;
            }
            else
            {
                Console.WriteLine("\nФайл не найден "+pathFile);
                return false;
            }
            
        }

        public void NewPathInFile(string newPath)
        {

            if (File.Exists(newPath))
            {

            }
            else
            {
                try
                {
                    using (FileStream fs = File.Create(newPath))
                    {

                    }
                }
                catch
                {
                    Console.WriteLine("Неверный путь к файлу");

                }
            }
            
            
        }

        public void NewWriteFileConsole(string pathInFile)
        {
            string wrtiteConsoleInFile = "";
            using (StreamWriter sw = File.AppendText(pathInFile))
            {
                while (wrtiteConsoleInFile != ".end")
                {
                    wrtiteConsoleInFile = Console.ReadLine();
                    if (wrtiteConsoleInFile == ".end") break; 
                    sw.WriteLine(wrtiteConsoleInFile);
                }

            }
        }

        public void OpenFile(string pathFile)
        {
            Process.Start(pathFile);
        }
              
        public void InteractiveConsoleInputFile()
        {
            do
            {
                if (SearchPathFile(PathInputFile))
                {
                    Console.WriteLine("\nИзменить путь? Yes(Y) No(N)");
                    if (CheckWriteOption())
                    {
                        Console.WriteLine("Введите новый путь:");
                        PathInputFile = Console.ReadLine();
                        InteractiveConsoleInputFile();
                        break;
                    }
                    else
                    {
                        SelectPathInputFile(PathInputFile);
                    }
                }
                else
                {
                    Console.WriteLine("\nСоздать файл? Yes(Y) No(N)");

                    if (CheckWriteOption())
                    {
                        SelectPathInputFile(PathInputFile, true);
                    }
                    else
                    {
                        Console.WriteLine("Зайдать новый путь");
                        PathInputFile = Console.ReadLine();
                        InteractiveConsoleInputFile();
                        break;
                    }

                }
                Console.WriteLine("Уверены с входящим файлом?: Yes(Y), No(N)");

            } while (!CheckWriteOption());
        }

        public void InteractiveConsoleOutFile()
        {
            do
            {
                if (SearchPathFile(PathOutFile))
                {
                    Console.WriteLine("\nИзменить путь? Yes(Y) No(N)");
                    if (CheckWriteOption())
                    {
                        Console.WriteLine("Введите новый путь:");
                        PathOutFile = Console.ReadLine();
                        InteractiveConsoleOutFile();
                        break;
                    }
                    else
                    {
                        SelectPathOutFile(PathOutFile);
                    }
                }
                else
                {
                    Console.WriteLine("\nСоздать файл? Yes(Y) No(N)");

                    if (CheckWriteOption())
                    {
                        SelectPathOutFile(PathOutFile, true);
                    }
                    else
                    {
                        Console.WriteLine("Зайдать новый путь");
                        PathOutFile = Console.ReadLine();
                        InteractiveConsoleOutFile();
                        break;
                    }

                }
                Console.WriteLine("Уверены с выходящим файлом?: Yes(Y), No(N)");

            } while (!CheckWriteOption());
        }

        public bool CheckWriteOption()
        {
            string errorWriteSybol = "Вы ввели не верное значение";
            //true = yes; false = no;
            string symbolYN = Console.ReadLine();
            if (symbolYN.Length == 1)
            {
                if (symbolYN[0] == 'Y' || symbolYN[0] == 'y')
                {
                    return true;
                }
                else
                {
                    if (symbolYN[0] == 'N' || symbolYN[0] == 'n')
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine(errorWriteSybol);
                        return CheckWriteOption();
                    }
                }

            }
            else
            {
                Console.WriteLine(errorWriteSybol);
                return CheckWriteOption();
            }


        }

    }
}
