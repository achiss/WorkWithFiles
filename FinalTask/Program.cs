// /Users/somovas/Downloads/Students.dat
//

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
            
            Console.WriteLine($" !!!: {receivedFilePath}");

            try
            {
                Console.WriteLine($" !!!: {receivedFilePath}");
                
                List<Student> students;
                ReadBinaryFile(receivedFilePath, out students);
                ShowStudents(students);
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

        private static string GetPathFromConsole()                                  // Есть ли смысл создавать пустую строку до того как считываем введённый текст
        {
            var receivedData = Console.ReadLine();
            receivedData = Path.GetFullPath(receivedData);

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

        private static void ReadBinaryFile(string filePath, out List<Student> students)
        {
            students = new List<Student>();
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
            }
        }
        
        private static void ShowStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Student Name: {student.StudentName}");
                Console.WriteLine($"Student Group: {student.StudentGroup}");
                Console.WriteLine($"Birth Date: {student.BirthDate}");
                Console.WriteLine();
            }
        }
    }

}