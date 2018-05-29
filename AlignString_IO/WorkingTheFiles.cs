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
        
        public void InFileSearchPath(ref string pathFile)
        {
            string categoryInFile = "Входящий";
            //метка для goto
            SearchPathFile:
           
            if (SearchPathFile(pathFile,categoryInFile))
            {
                Console.WriteLine("\nПродолжить работать в этом файле?: Yes (Y), No (N)");
                
                //Если null, то выдает ошибку. если значение 'nTEXT', то выдает true. 
                char boolChar = Console.ReadLine()[0];
                if (boolChar == 'N' || boolChar == 'n')
                {
                    Console.WriteLine("\nНовый путь:");
                    pathFile = Console.ReadLine();
                    NewPathInFile(pathFile);
                    goto SearchPathFile;
                }
                else
                {
                    OpenFile(pathFile);
                }
                
            }
            else
            {
                Console.WriteLine("\nЗадать новый путь к входящиму файлу");
                pathFile = Console.ReadLine();
                NewPathInFile(pathFile);
                goto SearchPathFile;
            }
        }

        public void OutFileSearchPath(ref string pathFile)
        {
            string categoryOutFile = "Выходящий";
            //метка для goto
            SearchPathFile:

            if (SearchPathFile(pathFile, categoryOutFile))
            {
                Console.WriteLine("\nПродолжить работать в этом файле?: Yes (Y), No (N)");
                
                //Если null, то выдает ошибку. если значение 'nTEXT', то выдает true. 
                char boolChar = Console.ReadLine()[0];
                if (boolChar == 'N' || boolChar == 'n')
                {
                    Console.WriteLine("\nНовый путь:");
                    pathFile = Console.ReadLine();
                    NewPathInFile(pathFile);
                    goto SearchPathFile;
                }

            }
            else
            {
                Console.WriteLine("\nЗадать новый путь к выходящиму файлу");
                pathFile = Console.ReadLine();
                NewPathInFile(pathFile);
                goto SearchPathFile;
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

        public void NewWriteFile()
        {
            
        }

        public void OpenFile(string pathFile)
        {
            var fileInfo = new FileInfo(pathFile);
            Console.WriteLine("Открыть {0} файл? Yes (Y), No (N)",fileInfo.Name);
            char boolChar = Console.ReadLine()[0];
            if (boolChar == 'Y' || boolChar == 'y')
            {
               
                Process.Start(pathFile);
            }
           
        }
    }
}
