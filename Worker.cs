using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8._6
{
    public enum WorkerFields {Id, Surname, Name, Age, Salary, Department}
    public class Worker
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value >= 14 && value <= 100)
                    age = value;
                else Console.WriteLine("Возрост за пределами диапозона");
            }
        }
        public int Salary { get; set; }
        public string Department { get; set; }

        public Worker(Guid id, string surname, string name, int age, int salary, string department)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Age = age;
            Salary = salary;
            Department = department;
        }

        public Worker(string surname, string name, int age, int salary, string department)
        {
            Id = Guid.NewGuid();
            Surname = surname;
            Name = name;
            Age = age;
            Salary = salary;
            Department = department;
        }
        public Worker()
        {
            Id = Guid.NewGuid();
            Surname = "";
            Name = "";
            Age = 25;
            Salary = 0;
            Department = "";
        }
        public void Print(string indent = "")
        {
            Console.WriteLine($"{indent}Id: {Id}");
            Console.WriteLine($"{indent}Surname: {Surname}");
            Console.WriteLine($"{indent}Name: {Name}");
            Console.WriteLine($"{indent}Age: {Age}");
            Console.WriteLine($"{indent}Salary: {Salary}");
            Console.WriteLine($"{indent}Department: {Department}");
        }
        public override string ToString()
        {
            return $"{Id};{Surname};{Name};{Age};{Salary};{Department}";
        }
    }
}
