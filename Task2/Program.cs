using System;
using System.IO;

namespace Task2
{

    class Program
    {
        private static string DirectoryPath { get; set; }
        private static long DirectorySize { get; set; }

        static void Main(string[] agrs)
        {
            DirectoryPath = GetDirectoryPath();
            var isFullyPath = CheckDataFromConsoleAsPath(DirectoryPath);
            var isDirectoryExist = CheckDirectoryExist(DirectoryPath);

            if ((isFullyPath) && (isDirectoryExist))
            {
                DirectorySize = GetDirectorySize();
                var kbSize = DirectorySize / 1024;
                var mbSize = kbSize / 1024;

                if (mbSize > 0)
                {
                    Console.WriteLine($"The size of choosing directory is {mbSize} mB");
                }
                else
                {
                    Console.WriteLine($"The size of choosing directory is {kbSize} kB");
                }

            }
            else
            {
                InformationMessage.ErrorMessage();
            }
        }

        private static string GetDirectoryPath()
        {
            var directoryPath = string.Empty;
            Console.WriteLine("Input directory path which size do you want to know: ");
            directoryPath = GetDataFromConsole();

            return directoryPath;
        }

        public static string GetDataFromConsole()
        {
            var receiveData = string.Empty;
            receiveData = Console.ReadLine();

            return receiveData;
        }

        public static bool CheckDataFromConsoleAsPath(in string DirectoryPath)
        {
            bool isFullyPath = Path.IsPathFullyQualified(DirectoryPath);

            if (isFullyPath)
            {
                return true;
            }
            else
            {
                var error = "The input data is not path";
                InformationMessage.ValueMessage(error);

                return false;
            }
        }

        public static bool CheckDirectoryExist(in string DirectoryPath)
        {
            bool isDirectoryExist = Directory.Exists((DirectoryPath));

            if (isDirectoryExist)
            {
                return true;
            }
            else
            {
                var error = "The directory doesn't exist";
                InformationMessage.ValueMessage(error);

                return false;
            }
        }

        public static long GetDirectorySize()
        {
            long directorySize = 0;
            string[] pathsList = Directory.GetFiles(DirectoryPath, "*", SearchOption.AllDirectories);

            foreach (var filePath in pathsList)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                directorySize += fileInfo.Length;
            }

            return directorySize;
        }
    }

}
