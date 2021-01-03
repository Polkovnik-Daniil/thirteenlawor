using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace ConsoleApp1
{
    class Find
    {
        public void Show()
        {
            string writePath = @"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\13\AllFileForWork\RDPlogfile.txt";
            List<string> list = new List<string>();
            string line;
            int bl = 0;
            StreamReader sr = new StreamReader(writePath);
            while ((line = sr.ReadLine()) != null)
            {
                // Используем второй прототип
                bool anyCars = list.Any(s => s.StartsWith("5"));
                Console.WriteLine("Наличие элемента в списке,\"X\": " + anyCars);
                if (anyCars == true || bl == 1)
                {
                    Console.WriteLine(line);
                    if(bl != 1)
                        bl++;
                }
                else
                {
                    bl = 0;
                }
            }
        }
    }
    class RDPFileManager
    {
        public static void Compress(string sourceFile, string compressedFile)
        {
            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                        Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                            sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                    }
                }
            }
        }
        public static void Decompress(string compressedFile, string targetFile)
        {
            // поток для чтения из сжатого файла
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetFile))
                {
                    // поток разархивации
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", targetFile);
                    }
                }
            }
        }
        public void Show()
        {
            // Specify the directory you want to manipulate.
            string path = @"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\13\AllFileForWork\RDPInspect";
            string path1 = @"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\13\AllFileForWork\RDPInspect";

            string path_2 = @"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\13\AllFileForWork\RDPInspect\RDPFiles";
            string path_21 = @"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\13\AllFileForWork\RDPInspect\RDPFiles";
            string path_3 = @"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\13\AllFileForWork\RDPfiles";


            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("Данная директория существует");
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("Директория была успешно создана {0}.", Directory.GetCreationTime(path));
                string path_two = path + @"\FileCopy";
                path += @"\rdpdirinfo.txt";
                FileStream fstream = File.Create(path);
                //Create empty file
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    var dir = new DirectoryInfo(@"c:\"); // папка с файлами 
                    foreach (FileInfo filein in dir.GetFiles())
                        sw.WriteLine(Path.GetFileNameWithoutExtension(filein.FullName));
                }
                File.Copy(path, "FileCopy");
                using (StreamReader sr = new StreamReader(path_two))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



                // Determine whether the directory exists.
                if (Directory.Exists(path_2))
                {
                    Console.WriteLine("Данная директория существует");
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di_2 = Directory.CreateDirectory(path_2);
                Console.WriteLine("Директория была успешно создана {0}.", Directory.GetCreationTime(path_2));
                path_2 = path_2 + @"\FileCopy.txt";
                File.Copy(path, path_2);
                File.Delete(path);


                // Determine whether the directory exists.
                if (Directory.Exists(path_3))
                {
                    Console.WriteLine("Данная директория существует");
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di_3 = Directory.CreateDirectory(path_2);
                Console.WriteLine("Директория была успешно создана {0}.", Directory.GetCreationTime(path_2));
                FileSystem.CopyDirectory(path_21, path_3);
                Directory.Move(path_21, path1);
                string sourceFile = path1 + @"\rdpdirinfo.txt"; // исходный файл
                string compressedFile = path1 + @"\rdpdirinfo.zip"; // сжатый файл
                string targetFile = path1 + @"\rdpdirinfo.txt"; // восстановленный файл
                // создание сжатого файла
                Compress(sourceFile, compressedFile);
                // чтение из сжатого файла
                Decompress(compressedFile, targetFile);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: {0}", e.ToString());
            }

        } 
    }
    class RDPLog
    {
        public string WriteToFile(string str, bool x)
        {
            string writePath = @"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\13\AllFileForWork\RDPlogfile.txt";
            try  
            {
                using (StreamWriter sw = new StreamWriter(writePath, x, System.Text.Encoding.Default))
                {
                    sw.WriteLine(DateTime.Now + "\n" + str);
                }
                return "Запись выполнена";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Запись не выполнена";
            }
        }
        public string ReadToFile(string str, bool x)
        {
            string writePath = @"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\13\AllFileForWork\RDPlogfile.txt";
            try
            {
                int count = 0;
                using (StreamReader sr = new StreamReader(writePath))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
                using (StreamReader sr = new StreamReader(writePath, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        count++;
                    }
                }
                Console.WriteLine("Количество записей в файле: " + count);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Произошла ошибка при чтении файла";
            }
            return "Выполнено чтение файла";
        }

    }
    class RDPDiskInfo 
    { 
        public void Show()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Диск: {0}", d.Name);
                Console.WriteLine("  Тип диска: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("  Метка тома: {0}", d.VolumeLabel);
                    Console.WriteLine("  Файловая система: {0}", d.DriveFormat);
                    Console.WriteLine(
                        "  Свободное место для текущего пользователя: \t{0, 15} байты",
                        d.AvailableFreeSpace);

                    Console.WriteLine(
                        "  Общее доступное пространство: \t\t{0, 15} байты",
                        d.TotalFreeSpace);

                    Console.WriteLine(
                        "  Общий размер диска: \t\t\t\t{0, 15} байты ",
                        d.TotalSize);
                }
            }
        }
    }
    class RDPFileInfo
    {
        public void Show()
        {
            string writePath = @"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\13\AllFileForWork\RDPlogfile.txt";
            string fileName = "RDPlogfile.txt";
            string fullPath;
            fullPath = Path.GetFullPath(fileName);
            Console.WriteLine("Наименование файла: " +
                fileName + "Путь файла: " + fullPath);
            Console.WriteLine("--------------------------------------------");
            DirectoryInfo di = new DirectoryInfo("c:\\");
            FileInfo[] fiArr = di.GetFiles();
            Console.WriteLine("Каталог {0} \nCодержит следующие файлы: ", di.Name);
            foreach (FileInfo f in fiArr)
                Console.WriteLine("\tРазмер {0} есть {1} байт.", f.Name, f.Length);
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Время создания файла: \t\t\t\t" + new FileInfo(writePath).CreationTime);
            DateTime dt = File.GetLastWriteTime(writePath);
            Console.WriteLine("Время когда файл был изменен последний раз:\t{0}.", dt);
        }
    }
    class RDPDirInfo
    {
        public void Show()
        {
            try
            {
                string writePath = @"D:\Даник\Учеба\3 семестр\ООП";
                if (Directory.Exists(writePath))
                {
                    Console.WriteLine("Подкаталоги:");
                    string[] dirs = Directory.GetDirectories(writePath);
                    foreach (string s in dirs)
                    {
                        Console.WriteLine("\t" + s);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Файлы:");
                    string[] files = Directory.GetFiles(writePath);
                    foreach (string s in files)
                    {
                        Console.WriteLine("\t" + s);
                    }
                    DirectoryInfo di = new DirectoryInfo(writePath);
                    Console.WriteLine("Время создания каталога: " + di.CreationTime);
                    Console.WriteLine("--------------------------------------------");
                    string[] dirs1 = Directory.GetDirectories(writePath, "*", System.IO.SearchOption.TopDirectoryOnly);
                    Console.WriteLine("Количество директориев в каталоге: {0}", dirs1.Length);
                    foreach (string dir in dirs1)
                    {
                        Console.WriteLine("\t" + dir);
                    }
                    Console.WriteLine("\nНаименование родительского каталога: " + System.IO.Directory.GetParent(writePath).FullName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RDPFileManager rDPFileManager = new RDPFileManager();
            RDPDiskInfo diskInfo = new RDPDiskInfo();
            RDPFileInfo fileInfo = new RDPFileInfo();
            RDPDirInfo dirInfo = new RDPDirInfo();
            RDPLog pr = new RDPLog();
            //////////////////////////////////////////////////////////////////////////////////////////////////
            diskInfo.Show();
            Console.WriteLine(pr.WriteToFile("Операция вывода информации о диске была совершена", true));
            Console.WriteLine("--------------------------------------------");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            //////////////////////////////////////////////////////////////////////////////////////////////////
            fileInfo.Show();
            Console.WriteLine(pr.WriteToFile("Операция вывода информации о файле была совершена", true));
            Console.WriteLine("--------------------------------------------");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            //////////////////////////////////////////////////////////////////////////////////////////////////
            dirInfo.Show(); 
            Console.WriteLine(pr.WriteToFile("Операция вывода информации о каталогах была совершена", true));
            Console.WriteLine("--------------------------------------------");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            //////////////////////////////////////////////////////////////////////////////////////////////////
            rDPFileManager.Show();
            Console.WriteLine(pr.WriteToFile("Операция вывода информации файловым менеджером была совершена", true));
            Console.WriteLine("--------------------------------------------");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            //////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine(pr.ReadToFile("Операция вывода информации из файла была совершена", true));
            Console.WriteLine("--------------------------------------------");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            //////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
