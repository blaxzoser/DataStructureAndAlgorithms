namespace TrainingLambdasAndLinq.POCOS
{
    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }

        public Employee(string name, string department, int salary)
        {
            Name = name;
            Department = department;
            Salary = salary;
        }
    }
}
