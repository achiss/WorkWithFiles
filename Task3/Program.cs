using System;
using System.IO;

namespace Task3
{

    class program
    {
        private static string DirectoryPath { get; set; }

        private static long DirectorySize { get; set; }

        public static void Main(string[] args)
        {
            Console.WriteLine($"The path is: {DirectoryPath}");

            Console.ReadKey();
        }

        public static void GetDirectoryPath()
        {
            var receivedData = string.Empty;
            Console.WriteLine("Please input the path: ");
            receivedData = GetDataFromConsole();

            DirectoryPath = receivedData;
        }

        public static string GetDataFromConsole()
        {
            var receivedData = string.Empty;
            receivedData = Console.ReadLine();
            receivedData = Path.GetFullPath(receivedData);

            return receivedData;
        }
    }

}
