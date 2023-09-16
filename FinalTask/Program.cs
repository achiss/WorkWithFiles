using System;
using System.IO;

namespace FinalTask
{

    class MainClass 
    {
        private static string StudentName { get; set; }
        private static string StudentGroup { get; set; }
        private static DateTime BirthDate { get; set; }

        public static void Main(string[] args) 
        {
            Console.WriteLine($"Please, input the path to file: ");

            var receivedPathToFile = string.Empty;
            receivedPathToFile = GetPathToFile();

            ReadFile(receivedPathToFile);


        }

        private static string GetPathToFile()           //path not string
        {
            var receivedData = string.Empty;
            receivedData = GetPathFromConsole();

            bool CheckFileExist = IsFileExist(receivedData);
            bool CheckNullData = GetPathToFileNotNull(receivedData);

            if ( (!CheckFileExist) && (CheckNullData) )
            {
                Console.WriteLine($"[INFO] {receivedData}\n[INFO] Not correct data.\nRepeat input data one more time: ");
                GetPathToFile();
            }

            return receivedData;
        }

        private static string GetPathFromConsole() 
        {
            var receivedData = string.Empty;
            receivedData = Path.GetFullPath(Console.ReadLine());

            return receivedData;
        }

        private static bool IsFileExist(in string dataToCheck) 
        {
            if (!File.Exists(dataToCheck))
            {
                Console.WriteLine($"[INFO] It cann't to read the file using received path!");

                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool GetPathToFileNotNull(in string dataToCheck) 
        {
            if (string.IsNullOrWhiteSpace(dataToCheck))
            {
                Console.WriteLine($"[INFO] Received path is null or contain something!");

                return false;
            }
            else
            {
                return true;
            }
        }

        private static void ReadFile(in string filePath)
        {
            var stringValue = string.Empty;
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                stringValue = reader.ReadString();
            }
            Console.WriteLine($"{stringValue}");
        }
    }

}
