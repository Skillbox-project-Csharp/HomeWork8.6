using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8._6
{
    class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department("hhhhhhhhhhhhhh");
            department.AddWorker(new Worker("sn1", "name1", 20, 1000, department.Name));
            department.AddWorker(new Worker("sn2", "name2", 20, 1002, department.Name));
            Organization org = new Organization("Amadeus");
            department.AddDepartment("Найм");
            department.AddDepartment("Уволнение");
            department.Departments[0].AddDepartment("Лучшие из лучших");
            department.Departments[0].AddDepartment("Лучшие из худших");
            department.Departments[1].AddDepartment("Растрел");
            department.Departments[1].Departments[0].AddDepartment("Уборка трупов");
            department.Departments[1].AddDepartment("Выгнать");
            department.Departments[1].AddWorker(new Worker("sn111111111", "name11111", 50, 100000, department.Name));
            department.Departments[1].AddWorker(new Worker("sn21111111", "name222222", 40, 200, department.Name));
            department.Departments[1].AddDepartment("Штраф");

            department.Departments[1].Departments[1].AddWorker(new Worker("Иванов", "Иван", 99, 10_000, department.Name));

            org.Departments.Add(department);
            org.Departments.Add(new Department("Логика"));
            org.Departments.Add(new Department("Отлов животных"));
            MenuOrganization menuOrganization = new MenuOrganization();
            menuOrganization.StartMenu(org);

           // Organization.PrintAll(department);
            // Console.WriteLine($"{department.Name} {department.DateCreat} {department.QuantityWorkers} {department.Departments.Count}");
        }
    }
}
