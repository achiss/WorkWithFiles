using System;

namespace Task3
{

    public class InformationMessage
    {
        public static void RequestData() => Console.WriteLine("Input directory path which size do you want to know: ");

        public static void DirectoryDataName() => Console.WriteLine("Input directory (folder) name: ");

        public static void ShowErrorApplication() => Console.WriteLine("[ERROR] Some probles with the app. Restart the app.");

        public static void ShowErrorMethod(in string message)
        {
            Console.WriteLine($"[INFO] Method of the app, can't be finished! \n[INFO] {message}");
        }

        public static void ShowInformation(in string directoryPath, in long SizeMesasge, in int FileCounInfo)
        {
            Console.WriteLine($"\t Info about {directoryPath}:\n" +
                              $"\t - The number of files (include) catalogs in directory are: {FileCounInfo}.\n" +
                              $"\t - Directory size is: {SizeMesasge} byte.");
        }
    }

}
