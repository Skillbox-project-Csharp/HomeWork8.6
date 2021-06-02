using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8._6
{
    public class Organization
    {
        public string Name { get; set; }
        public List<Department> Departments { get; set; }

        public Organization(string name)
        {
            Name = name;
            Departments = new List<Department>();
        }

        public Organization()
        {
            Name = "Amadeus";
            Departments = new List<Department>();
        }

        public static void PrintAll(Department department, string indent = " ")
        {
            if (indent == " ")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{department.Name} ");
                Console.ResetColor();
                Console.WriteLine($"{ department.DateCreat} Кол-во раб.:{ department.QuantityWorkers}");
                
                department.PrintWorkers(indent);
            }

            foreach (var dep in department.Departments)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{indent}{dep.Name} ");
                Console.ResetColor();
                Console.WriteLine($"{ dep.DateCreat} Кол-во раб.:{ dep.QuantityWorkers}");
                dep.PrintWorkers(indent + " ");
                PrintAll(dep, indent + " ");
            }

            return;
        }

        public static void PrintSelectDepartment(List<Department> deps)
        {
            int count = deps.Count;
            for (int i = 0; i < count; i++)
                Console.WriteLine($"{i + 1}.{deps[i].Name}");

        }

        public  void RemoveSelectDepartmen(Department department, List<Department> deps)
        {
            if (deps.RemoveAll(o => o == department) != 0)
                return;
            else
            {
                foreach(var element in deps)
                {
                    RemoveSelectDepartmen(department, element.Departments);
                }
            }
            return;
        }
        
    }
}
