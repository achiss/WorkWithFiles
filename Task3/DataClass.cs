using System;

namespace Task3
{

    public class DataClass
    {
        protected static string DirectoryPath { get; set; }

        protected static long DirectorySize { get; set; }

        public DataClass(string directoryPath, long directorySize)
        {
            DirectoryPath = directoryPath;
            DirectorySize = directorySize;
        }

        static void ShowDataClassInformation(in string DirectoryPath, in long DirectorySize) =>
            Console.WriteLine($"The directory path is {DirectoryPath} and a size is {DirectorySize} byte.");
    }

}
