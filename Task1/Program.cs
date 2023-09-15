using System;
using System.IO;
using System.Threading;

namespace Task1
{
    class Program
    {
        static string DirectoryPath { get; set; }
        static string DirectoryName { get; set; }

        static string[] FilesList { get; set; }
        static string[] FoldersList { get; set; }

        public static void Main(string[] agrs)
        {
            while (true)
            {
                if (DirectoryPath == null)
                {
                    DirectoryPath = GetDirectoryPath();
                }

                if (DirectoryName == null)
                {
                    DirectoryName = GetDirectoryName();
                }

                var boolExistDirectory = BoolExistDirectory();

                if (boolExistDirectory)
                {
                    CreateDirectory(DirectoryPath, DirectoryName);
                }

                FoldersList = GetFoldersList();
                FilesList = GetFilesList();
            
                DirectoryInfo dirInfo = new DirectoryInfo(DirectoryPath);
                if (dirInfo.Exists)
                {
                    Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                }

                CleanDirectory();
                Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                
                Thread.Sleep(TimeSpan.FromMinutes(30));
                
                Console.ReadKey();
            }
            
        }

        static string GetDataFromConsole() 
        {
            string receivedDataString = Console.ReadLine();
            var error = "Data shoud be contained letters";

            if (!string.IsNullOrWhiteSpace(receivedDataString))
            {
                return receivedDataString;
            }
            else
            {
                ShowMessage(error);
                return GetDataFromConsole();
            }
        }

        static string GetDirectoryPath() 
        {
            Console.WriteLine("Input path: ");
            var receivedData = GetDataFromConsole();
            var error = "Please input the directory path";

            if ( (receivedData.Contains("/")) || (receivedData.Contains("\\")) ) 
            {
                return receivedData;
            }
            else
            {
                ShowMessage(error);
                return GetDirectoryPath();
            }
        }

        static string GetDirectoryName() 
        {
            Console.WriteLine("Input name: ");
            var receivedData = GetDataFromConsole();
            var error = "Please input the directory name";

            if ( (!receivedData.Contains("/")) || (!receivedData.Contains("\\")) )
            {
                return receivedData;
            }
            else
            {
                ShowMessage(error);
                return GetDirectoryName();
            }
        }

        static bool BoolExistDirectory() 
        {
            if (Directory.Exists(DirectoryPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void CreateDirectory(in string directoryPath, in string directoryName)
        {
            DirectoryInfo workDirectory = new DirectoryInfo(directoryPath);
            if (!workDirectory.Exists)
                workDirectory.Create();

            workDirectory.CreateSubdirectory(directoryName);
        }

        static string[] GetFoldersList()
        {
            string[] workDirectory = Directory.GetFiles(DirectoryPath);

            return workDirectory;
        }

        static string[] GetFilesList() 
        {
            string[] workDirectory = Directory.GetDirectories(DirectoryPath);

            return workDirectory;
        }

        static void CleanDirectory()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(DirectoryName);
            dirInfo.Delete(true);
            Console.WriteLine("Directory has been deleted.");
        }

        static void ShowMessage(string error)
        {
            Console.WriteLine($"[ERROR] {error}.");
        }
    }
}
