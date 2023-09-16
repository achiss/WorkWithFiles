using System;
using System.IO;

namespace Task3
{

    class program
    {
        private static int FileCount = 0;
        
        static void Main(string[] args)
        {
            var directoryPath = string.Empty;
            
            InformationMessage.RequestData();
            directoryPath = GetData();

            try
            {
                bool isPathNotNull = CheckDirectoryPathOnNullString(directoryPath);
                bool isDirectoryExist = CheckDirectoryExist(directoryPath);
                
                if ((isPathNotNull) && (!isDirectoryExist))
                {
                    var receivedDataName = string.Empty;
                    InformationMessage.DirectoryDataName();
                    receivedDataName = GetData();

                    CreateFolder(directoryPath, receivedDataName);
                }
                
                if ( (isPathNotNull) && (isDirectoryExist) )
                {
                    GetNumberOfEntriesInDirectory(directoryPath);
                    var directorySize = GetDirectorySize(directoryPath);
                    var directoryEntriesCount = FileCount;
                    InformationMessage.ShowInformation(directoryPath, directorySize, directoryEntriesCount);
                    
                    CleanDirectory(directoryPath);
                    directorySize = GetDirectorySize(directoryPath);
                    GetNumberOfEntriesInDirectory(directoryPath);
                    directoryEntriesCount = FileCount;
                    InformationMessage.ShowInformation(directoryPath, directorySize, directoryEntriesCount);
                }
                
            }
            catch (Exception e)
            {
                InformationMessage.ShowErrorApplication();
                throw;
            }
            
            
            Console.ReadKey();
        }

        private static string GetData() 
        {
            var receivedData = string.Empty;
            receivedData = GetDataFromConsole();

            return receivedData;
        }

        private static string GetDataFromConsole() 
        {
            var receivedData = string.Empty;
            receivedData = Console.ReadLine();

            return receivedData;
        }

        private static bool CheckDirectoryPathOnNullString(in string directoryPath) 
        {
            var receivedData = string.Empty;
            receivedData = directoryPath;
            bool isPathNotNull = string.IsNullOrWhiteSpace(receivedData);

            if (!isPathNotNull)
            {
                return true;
            }
            else
            {
                var error = "The input data is NULL.";
                InformationMessage.ShowErrorMethod(error);
                return false;
            }
        }
        
        private static bool CheckDirectoryExist(in string directoryPath) 
        {
            bool isDirectoryExist = Directory.Exists(directoryPath);

            if (isDirectoryExist)
            {
                return true;
            }
            else
            {
                var error = "The folder not exist.";
                InformationMessage.ShowErrorMethod(error);
                
                return false;
            }
        }

        private static void CreateFolder(in string directoryPath, in string directoryName) 
        {
            bool isDirectoryExist = CheckDirectoryExist(directoryPath);
            DirectoryInfo workDirectory = new DirectoryInfo(directoryPath);
            
            if (isDirectoryExist)
                workDirectory.Create();

            workDirectory.CreateSubdirectory(directoryName);
        }

        private static long GetDirectorySize(in string directoryPath)
        {
            long directorySize = 0;
            string[] pathsList = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

            foreach (var filePath in pathsList)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                directorySize += fileInfo.Length;
            }

            return directorySize;
        }

        private static void GetNumberOfEntriesInDirectory(in string directoryPath)
        {
            FileCount += Directory.GetFiles(directoryPath).Length;

            foreach (string subdirectory in Directory.GetDirectories(directoryPath))
            {
                GetNumberOfEntriesInDirectory(subdirectory);
            } 
        }
        
        private static void CleanDirectory(in string DirectoryName)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(DirectoryName);
            dirInfo.Delete(true);
            Console.WriteLine("Directory has been deleted.");
        }
    }

}
