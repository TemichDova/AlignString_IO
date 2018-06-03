using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlignString_IO
{
    class WorkingTheFiles
    {
        
        public string PathToInFile { get; set; }
        public string PathToOutFile { get; set; }

        public void InFileSearchPath(string pathFile)
        {
            string categoryInFile = "Входящий";
                    
            if (SearchPathFile(pathFile,categoryInFile))
            {
                Console.WriteLine("\nПродолжить работать в этом файле?: Yes (Y), No (N)");
                                                             
                if (!GetCheckWriteOption())
                {
                    Console.WriteLine("\nНовый путь:");
                    PathToInFile = Console.ReadLine();
                    NewPathInFile(PathToInFile);
                    InFileSearchPath(PathToInFile);
                }
                else
                {
                    Console.WriteLine("\nДополнить файл через консоль?: Yes (Y), No (N)");
                    if (GetCheckWriteOption())
                    {
                        Console.WriteLine("Введите новые данные, после завршение напише '.end' :\n");
                        NewWriteFileConsole(pathFile);
                    }
                    else
                    {
                        OpenFile(pathFile);
                    }
                }
                                              
            }
            else
            {
                Console.WriteLine("\nЗадать новый путь к входящиму файлу");
                PathToInFile = Console.ReadLine();
                NewPathInFile(PathToInFile);
                InFileSearchPath(PathToInFile);
            }
        }

        public void OutFileSearchPath(string pathFile)
        {
            string categoryOutFile = "Выходящий";
            
            if (SearchPathFile(pathFile, categoryOutFile))
            {
                Console.WriteLine("\nПродолжить работать в этом файле?: Yes (Y), No (N)");
                               
                if (!GetCheckWriteOption())
                {
                    Console.WriteLine("\nНовый путь:");
                    PathToOutFile = Console.ReadLine();
                    NewPathInFile(PathToOutFile);
                    OutFileSearchPath(PathToOutFile);
                }

            }
            else
            {
                Console.WriteLine("\nЗадать новый путь к выходящиму файлу");
                PathToOutFile = Console.ReadLine();
                NewPathInFile(PathToOutFile);
                OutFileSearchPath(PathToOutFile);
            }
        }

        public bool SearchPathFile(string pathFile, string categoryIO)
        {
            var fileInfo = new FileInfo(pathFile);

            if (File.Exists(pathFile))
            {
                Console.WriteLine("\nДоступен исходный {1} файл {0}", fileInfo.Name, categoryIO);
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
            string categoryFile = "Существующий";
            if (SearchPathFile(newPath, categoryFile))
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
            var fileInfo = new FileInfo(pathFile);
            Console.WriteLine("Открыть {0} файл? Yes (Y), No (N)",fileInfo.Name);
            
            if (GetCheckWriteOption())
            {
                Process.Start(pathFile);
            }
           
        }
              

        public bool GetCheckWriteOption()
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
                    if(symbolYN[0] == 'N' || symbolYN[0] == 'n')
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine(errorWriteSybol);
                        return GetCheckWriteOption();
                    }
                }

            }
            else
            {
                Console.WriteLine(errorWriteSybol);
                return GetCheckWriteOption();
            }

            
        }
                
    }
}
