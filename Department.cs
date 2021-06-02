using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8._6
{
    public class Department
    {
        public string Name { get; set; }
        public DateTime DateCreat { get;  set; } 
        public int QuantityWorkers { get;  set; } 
        public List<Department> Departments { get; set; }
        public List<Worker> Workers { get; set; }
        public Department(string name, DateTime dateCreat, int quantityWorkers, List<Department> departments) : this(name)
        {
            DateCreat = dateCreat;
            QuantityWorkers = quantityWorkers;
            Departments = departments;
        }
        public Department(string name)
        {
            Name = name;
            Departments = new List<Department>();
            Workers = new List<Worker>();
            DateCreat = DateTime.Now;
            QuantityWorkers = 0;
        }
        public Department()
        {
            Name = "";
            Departments = new List<Department>();
            Workers = new List<Worker>();
            DateCreat = DateTime.Now;
            QuantityWorkers = 0;
        }


        public bool AddWorker(Worker worker)
        {
            if (QuantityWorkers <= 1_000_000_000)
            {
                Workers.Add(worker);
                QuantityWorkers++;
                return true;
            }
            else
            {
                Console.WriteLine("Превышен лимит сотрудников!");
                return false;
            }
        }
        public void RemoveWorker(int index)
        {
            if (index >= 0 && index < QuantityWorkers)
            {
                Workers.RemoveAt(index);
                QuantityWorkers--;
            }
        }
        public void RemoveAllWorkers(string str, WorkerFields workerField)
        {
            switch (workerField)
            {
                case WorkerFields.Id:
                    Guid guid;
                    if (Guid.TryParse(str, out guid))
                        Workers.RemoveAll(o => o.Id == guid);
                    break;
                case WorkerFields.Surname:
                    Workers.RemoveAll(o => o.Surname == str);
                    break;
                case WorkerFields.Name:
                    Workers.RemoveAll(o => o.Name == str);
                    break;
                case WorkerFields.Age:
                    int age;
                    if (int.TryParse(str, out age))
                        Workers.RemoveAll(o => o.Age == age);
                    break;
                case WorkerFields.Salary:
                    int salary;
                    if (int.TryParse(str, out salary))
                        Workers.RemoveAll(o => o.Salary == salary);
                    break;
                case WorkerFields.Department:
                    Workers.RemoveAll(o => o.Department == str);
                    break;
            }
        }
        /// <summary>
        /// Добавить под департамент
        /// </summary>
        /// <param name="name"></param>
        public void AddDepartment(string name)
        {
            Departments.Add(new Department(name));
        }
        public void AddDepartment(Department dep)
        {
            Departments.Add(dep);
        }
        /// <summary>
        /// Удалить под департамент по названию
        /// </summary>
        /// <param name="name"></param>
        public void RemoveDepartment(string name)
        {
            Departments.RemoveAll((o) => o.Name == name);
        }
        /// <summary>
        /// Удалить под департамент по индексу
        /// </summary>
        /// <param name="index"></param>
        public void RemoveDepartment(int index)
        {
            if (index >= 0 && index < Departments.Count)
                Departments.RemoveAt(index);
        }
        public void RenameDepartment(string name)
        {
            Name = name;
            foreach (var worker in Workers)
                worker.Department = name;
        }

        public void SortWorker(WorkerFields workerFields)
        {
            switch (workerFields)
            {
                case WorkerFields.Id:
                    Workers.Sort((o1, o2) => o1.Id.CompareTo(o2.Id));
                    break;
                case WorkerFields.Surname:
                    Workers.Sort((o1, o2) => o1.Surname.CompareTo(o2.Surname));
                    break;
                case WorkerFields.Name:
                    Workers.Sort((o1, o2) => o1.Name.CompareTo(o2.Name));
                    break;
                case WorkerFields.Age:
                    Workers.Sort((o1, o2) => o1.Age.CompareTo(o2.Age));
                    break;
                case WorkerFields.Salary:
                    Workers.Sort((o1, o2) => o1.Salary.CompareTo(o2.Salary));
                    break;
                case WorkerFields.Department:
                    Workers.Sort((o1, o2) => o1.Department.CompareTo(o2.Id));
                    break;
            }
        }

        public void PrintWorkers(string indent = "")
        {
            for (int i = 0; i < QuantityWorkers; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{indent + " "}Работник {i + 1}:");
                Console.ResetColor();
                Workers[i].Print(indent + "  ");
            }
        }
    }
}
