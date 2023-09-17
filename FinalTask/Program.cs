using System;
using System.Collections.Generic;
using System.IO;

namespace FinalTask
{

    class MainClass 
    {

        public static void Main(string[] args) 
        {
            var receivedFilePath = string.Empty;

            Console.WriteLine($"Please, input the path to file: ");
            receivedFilePath = GetPathToFile();

            try
            {
                var studentsList = new List<Student>();

                studentsList = ReadBinaryFile(receivedFilePath);
                foreach (var student in studentsList)
                {
                    Console.WriteLine($"{student.StudentName}");
                    Console.WriteLine($"{student.StudentGroup}");
                    Console.WriteLine($"{student.BirthDate}");
                }
            }
            catch
            {

            }
        }

        private static string GetPathToFile()                                      // path not 'text (bla-bla-...)'
        {
            var receivedData = string.Empty;
            receivedData = GetPathFromConsole();                                   //  Path.GetFullPath(targetPath)

            bool CheckFileExist = IsFileExist(receivedData);                       //  File.Exists(targetPath)
            bool CheckNullData = GetPathToFileNotNull(receivedData);               //  string.IsNullOrWhiteSpace(targetPath)

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

        private static List<Student> ReadBinaryFile(in string filePath)
        {
            List<Student> students = new List<Student>();
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string studentName = reader.ReadString();
                    string studentGroup = reader.ReadString();
                    long birhDate = reader.ReadInt64();
                    DateTime birthDayDate = new DateTime(birhDate);

                    Student student = new Student(studentName, studentGroup, birthDayDate);
                    students.Add(student);
                }

            return students;
            }
        }
    }

}