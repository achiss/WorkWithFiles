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

            Console.WriteLine("Please, input the path to file: ");
            receivedFilePath = GetPathToFile();

            List<Student> studentsList;
            try
            {
                studentsList = ReadBinaryFile(receivedFilePath);
                ShowStudents(studentsList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] An error occurred while reading the file:");
                Console.WriteLine(ex.Message);
            }
        }

        private static string GetPathToFile()
        {
            var receivedData = string.Empty;
            receivedData = GetPathFromConsole();

            while (!IsFileValid(receivedData))
            {
                Console.WriteLine("[INFO] Invalid file path. Please enter a valid path:");
                receivedData = GetPathFromConsole();
            }

            return receivedData;
        }

        private static string GetPathFromConsole()
        {
            return Path.GetFullPath(Console.ReadLine());
        }

        private static bool IsFileValid(string filePath)
        {
            return ( !string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath) );
        }
 
        private static List<Student> ReadBinaryFile(string filePath)
        {
            List<Student> studentsList = new List<Student>();
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    string studentName = reader.ReadString();
                    string studentGroup = reader.ReadString();
                    long birthDateTicks = reader.ReadInt64();

                    DateTime birthDate = new DateTime(birthDateTicks);
                    Student student = new Student(studentName, studentGroup, birthDate);
                    studentsList.Add(student);
                }
            }
            return studentsList;
        }

        private static void ShowStudents(List<Student> studentsList)
        {
            foreach (var student in studentsList)
            {
                Console.WriteLine($"Student Name: {student.StudentName}");
                Console.WriteLine($"Student Group: {student.StudentGroup}");
                Console.WriteLine($"Birth Date: {student.BirthDate}");
                Console.WriteLine();
            }
        }
    }
}
