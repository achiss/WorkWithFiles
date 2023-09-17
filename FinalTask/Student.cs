using System;
namespace FinalTask
{

    public class Student
    {
        public string StudentName { get; set; }

        public string StudentGroup { get; set; }

        public DateTime BirthDate { get; set; }

        public Student(string studentName, string studentGroup, DateTime birthDate)
        {
            StudentName = studentName;
            StudentGroup = studentGroup;
            BirthDate = birthDate;
        }
    }

}
