using System.Collections.Generic;

namespace TrainingLambdasAndLinq.POCOS
{
    public class Student
    {
        public string Name { get; set; }
        public List<string> Courses { get; set; }

        public Student(string name, List<string> courses)
        {
            Name = name;
            Courses = courses;
        }
    }
}
