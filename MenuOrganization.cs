using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8._6
{
    class MenuOrganization
    {
        public Organization Organization { get; set; } = new Organization("Amadeus");
        private Stack<List<Department>> StackDepart { get; set; } = new Stack<List<Department>>();
        private Department SelectedDepartment { get; set; } = null;
        public void StartMenu(Organization organization = null)
        {

            if (organization != null)
                Organization = organization;
            StackDepart = new Stack<List<Department>>();
            string massegeStartMenu = String.Empty;
            massegeStartMenu += "1.Выбрать департамент\n";
            massegeStartMenu += "2.Добавить департамент\n";
            massegeStartMenu += "3.Переименовать департамент\n";
            massegeStartMenu += "4.Удалить департамент\n";
            massegeStartMenu += "5.Работа с сотрудниками\n";
            massegeStartMenu += "6.Сохранить\n";
            massegeStartMenu += "7.Загрузить\n";
            massegeStartMenu += "8.Выход\n";
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                PrintAllDepartment();
                if (SelectedDepartment != null)
                {
                    Console.Write("Текущий депортамент: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(SelectedDepartment.Name);
                    Console.ResetColor();
                }

                Console.WriteLine(massegeStartMenu);
                switch (InsertInt(1, 8))
                {
                    case 1:
                        if (Organization.Departments.Count != 0)
                        {
                            if (StackDepart.Count == 0)
                                SwitchDepartmen(Organization.Departments);
                            else SwitchDepartmen(StackDepart.Pop());
                        }
                        break;
                    case 2:
                        if (SelectedDepartment == null)
                            Organization.Departments.Add(EnterDepartmentMenu());
                        else SelectedDepartment.AddDepartment(EnterDepartmentMenu());
                        Console.Clear();
                        break;
                    case 3:
                        RenameDepartmantMenu();
                        break;
                    case 4:
                        RemoveDepartmentMenu();
                        break;
                    case 5:
                        if (SelectedDepartment != null)
                            WorkersMenu();
                        break;
                    case 6:
                        SaveMenu(SelectPathMenu());
                        break;
                    case 7:
                        LoadMenu(SelectPathMenu());
                        break;
                    case 8:
                        exit = true;
                        break;
                }
            }
        }
        private Department EnterDepartmentMenu()
        {
            Console.Write("Название департамента: ");

            return new Department(Console.ReadLine());
        }
        private Worker EnterWorkerMenu()
        {
            Console.Write($"Surname: ");
            string surName = Console.ReadLine();
            Console.Write($"Name: ");
            string name = Console.ReadLine();
            Console.Write($"Age: ");
            int age = InsertInt(16, 130);
            Console.Write($"Salary: ");
            int salary = InsertInt(0, int.MaxValue);
            return new Worker(surName, name, age, salary, SelectedDepartment.Name);

        }
        private void SwitchDepartmen(List<Department> deps)
        {
            Console.Clear();
            int depsLength = deps.Count;
            int index = 0;
            List<int> lengthRows = new List<int>();
            foreach (var e in deps)
                lengthRows.Add(e.Name.Length + 2);

            Organization.PrintSelectDepartment(deps);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, index);
            Console.Write($"{index + 1}.{deps[index].Name}");
            Console.ResetColor();
            Console.SetCursorPosition(lengthRows[index], index);
            while (true)
            {

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                        {
                            Console.SetCursorPosition(0, index);
                            Console.Write($"{index + 1}.{deps[index].Name}");
                            index--;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(0, index);
                            Console.Write($"{index + 1}.{deps[index].Name}");
                            Console.ResetColor();
                            Console.SetCursorPosition(lengthRows[index], index);
                        }
                        else Console.CursorLeft--;

                        break;
                    case ConsoleKey.DownArrow:
                        if (index < depsLength - 1)
                        {
                            Console.SetCursorPosition(0, index);
                            Console.Write($"{index + 1}.{deps[index].Name}");
                            index++;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(0, index);
                            Console.Write($"{index + 1}.{deps[index].Name}");
                            Console.ResetColor();
                            Console.SetCursorPosition(lengthRows[index], index);
                        }
                        else Console.CursorLeft--;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (StackDepart.Count != 0)
                        {
                            SwitchDepartmen(StackDepart.Pop());
                            return;
                        }
                        else
                        {
                            SelectedDepartment = null;
                            return;
                        }

                        break;
                    case ConsoleKey.RightArrow:
                        int nextCount = deps[index].Departments.Count;
                        if (nextCount > 0)
                        {
                            StackDepart.Push(deps);
                            SwitchDepartmen(deps[index].Departments);
                            return;
                        }
                        else Console.CursorLeft--;

                        break;
                    case ConsoleKey.Enter:
                        StackDepart.Push(deps);
                        SelectedDepartment = deps[index];
                        return;
                        break;
                    default:
                        Console.CursorLeft--;
                        break;
                }
            }
        }
        private Department ChooseDepartment(List<Department> deps)
        {
            Console.Clear();
            int depsLength = deps.Count;
            int index = 0;
            List<int> lengthRows = new List<int>();
            foreach (var e in deps)
                lengthRows.Add(e.Name.Length + 2);

            Organization.PrintSelectDepartment(deps);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, index);
            Console.Write($"{index + 1}.{deps[index].Name}");
            Console.ResetColor();
            Console.SetCursorPosition(lengthRows[index], index);
            while (true)
            {

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                        {
                            Console.SetCursorPosition(0, index);
                            Console.Write($"{index + 1}.{deps[index].Name}");
                            index--;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(0, index);
                            Console.Write($"{index + 1}.{deps[index].Name}");
                            Console.ResetColor();
                            Console.SetCursorPosition(lengthRows[index], index);
                        }
                        else Console.CursorLeft--;

                        break;
                    case ConsoleKey.DownArrow:
                        if (index < depsLength - 1)
                        {
                            Console.SetCursorPosition(0, index);
                            Console.Write($"{index + 1}.{deps[index].Name}");
                            index++;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(0, index);
                            Console.Write($"{index + 1}.{deps[index].Name}");
                            Console.ResetColor();
                            Console.SetCursorPosition(lengthRows[index], index);
                        }
                        else Console.CursorLeft--;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (StackDepart.Count != 0)
                        {

                            return ChooseDepartment(StackDepart.Pop());
                        }

                        break;
                    case ConsoleKey.RightArrow:
                        int nextCount = deps[index].Departments.Count;
                        if (nextCount > 0)
                        {
                            StackDepart.Push(deps);
                            return ChooseDepartment(deps[index].Departments);
                        }
                        else Console.CursorLeft--;

                        break;
                    case ConsoleKey.Enter:
                        StackDepart.Push(deps);
                        return deps[index];
                        break;
                    default:
                        Console.CursorLeft--;
                        break;
                }
            }
        }
        private void PrintAllDepartment()
        {
            Console.WriteLine($"Организация: {Organization.Name}");
            if (SelectedDepartment == null)
                foreach (var dep in Organization.Departments)
                    Organization.PrintAll(dep);
            else
            {
                Organization.PrintAll(SelectedDepartment);
            }
        }
        private void RenameDepartmantMenu()
        {
            if (SelectedDepartment != null)
            {
                Console.Write("Введите новое имя депортамента: ");
                SelectedDepartment.RenameDepartment(Console.ReadLine());
            }
        }
        private void RemoveDepartmentMenu()
        {
            if (SelectedDepartment == null)
            {
                Organization.Departments.Clear();
                StackDepart.Clear();
                SelectedDepartment = null;
            }
            else Organization.RemoveSelectDepartmen(SelectedDepartment, Organization.Departments);
            SelectedDepartment = null;
            StackDepart.Clear();
            Console.Clear();
        }
        private void WorkersMenu()
        {

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(SelectedDepartment.Name);
                Console.ResetColor();
                SelectedDepartment.PrintWorkers();
                Console.WriteLine("1.Дабавить работника");
                Console.WriteLine("2.Удалить работника");
                Console.WriteLine("3.Изменить данные работника");
                Console.WriteLine("4.Отсортировать список работников");
                Console.WriteLine("5.Назад");
                switch (InsertInt(1, 5))
                {
                    case 1:
                        SelectedDepartment.AddWorker(EnterWorkerMenu());
                        break;
                    case 2:
                        Console.Write("Номер работника: ");
                        SelectedDepartment.RemoveWorker(InsertInt(0, int.MaxValue) - 1);
                        break;
                    case 3:
                        Console.Write("Номер работника: ");
                        ChangeWorker(InsertInt(0, int.MaxValue) - 1);
                        break;
                    case 4:
                        SortWorkerFields(SelectedDepartment.Workers);
                        break;
                    case 5:
                        exit = true;
                        break;
                }

            }
        }
        private void ChangeWorker(int index)
        {
            if (index >= 0 && index < SelectedDepartment.QuantityWorkers)
            {
                bool exit = false;
                while (!exit)
                {
                    Console.Clear();
                    SelectedDepartment.Workers[index].Print();
                    Console.WriteLine("1.Изменить фамилию");
                    Console.WriteLine("2.Изменить имя");
                    Console.WriteLine("3.Изменить возрост");
                    Console.WriteLine("4.Изменить заработную плату");
                    Console.WriteLine("5.Сгенерировать новый идетнификатор");
                    Console.WriteLine("6.Сменить депортамент");
                    Console.WriteLine("7.Назад");
                    switch (InsertInt(1, 7))
                    {
                        case 1:
                            Console.Write("Фамилия: ");
                            SelectedDepartment.Workers[index].Surname = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("Имя: ");
                            SelectedDepartment.Workers[index].Name = Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("Возраст: ");
                            SelectedDepartment.Workers[index].Age = InsertInt(0, int.MaxValue);
                            break;
                        case 4:
                            Console.Write("Возраст: ");
                            SelectedDepartment.Workers[index].Salary = InsertInt(0, int.MaxValue);
                            break;
                        case 5:
                            SelectedDepartment.Workers[index].Id = Guid.NewGuid();
                            break;
                        case 6:
                            Department choseDep = ChooseDepartment(Organization.Departments);
                            if (choseDep != null)
                            {
                                SelectedDepartment.Workers[index].Department = choseDep.Name;
                                if (choseDep.AddWorker(SelectedDepartment.Workers[index]))
                                {
                                    SelectedDepartment.RemoveWorker(index);
                                    return;
                                }
                                else SelectedDepartment.Workers[index].Department = SelectedDepartment.Name;
                            }
                            break;
                        case 7:
                            exit = true;
                            break;
                    }
                }
            }
        }
        private void SortWorkerFields(List<Worker> listWorkers)
        {

            Console.WriteLine("\t1.Фамилия");
            Console.WriteLine("\t2.Имя");
            Console.WriteLine("\t3.Возрост");
            Console.WriteLine("\t4.Зарплата");
            Console.WriteLine("\t5.ID");
            Console.WriteLine("\t6.Департамент");
            switch (InsertInt(1, 6))
            {
                case 1:
                    listWorkers.Sort((o1, o2) => o1.Surname.CompareTo(o2.Surname));
                    break;
                case 2:
                    listWorkers.Sort((o1, o2) => o1.Name.CompareTo(o2.Name));
                    break;
                case 3:
                    listWorkers.Sort((o1, o2) => o1.Age.CompareTo(o2.Age));
                    break;
                case 4:
                    listWorkers.Sort((o1, o2) => o1.Salary.CompareTo(o2.Salary));
                    break;
                case 5:
                    listWorkers.Sort((o1, o2) => o1.Id.CompareTo(o2.Id));
                    break;
                case 6:
                    listWorkers.Sort((o1, o2) => o1.Department.CompareTo(o2.Department));
                    break;
            }
        }
        private void SaveMenu(string path)
        {
            Console.WriteLine("\t\t1.Сохранть в XML формате");
            Console.WriteLine("\t\t2.Сохранть в JSON формате");
            Console.WriteLine("\t\t3.Назад");
            switch (InsertInt(1, 3))
            {
                case 1:
                    path += ".xml";
                    if (SaveOrganization(path, new XMLManager()))
                        Console.WriteLine($"Файл {path} сохранен");
                    else Console.WriteLine($"Ошибка сохранения файла {path}!!!");
                    break;
                case 2:
                    path += ".json";
                    if (SaveOrganization(path, new JSONManager()))
                        Console.WriteLine($"Файл {path} сохранен");
                    else Console.WriteLine($"Ошибка сохранения файла {path}!!!");
                    break;
                case 3:
                    break;
            }
            Console.ReadKey();
        }
        private string SelectPathMenu()
        {
            string path = String.Empty;
            Console.WriteLine("\t1.Путь по умолчание");
            Console.WriteLine("\t2.Выбрать путь и имя");
            switch(InsertInt(1,2))
            {
                case 1:
                    path = AppContext.BaseDirectory+@"\org";
                    break;
                case 2:
                    Console.Write("Путь: ");
                    path += Console.ReadLine();
                    Console.Write("Имя: ");
                    path +=@"\" + Console.ReadLine();
                    break;
            }
            return path;
        }
        private void LoadMenu(string path)
        {
            Console.WriteLine("\t\t1.Зугрузить файл с XML форматом");
            Console.WriteLine("\t\t2.Зугрузить файл с JSON форматом");
            Console.WriteLine("\t\t3.Назад");

            switch (InsertInt(1, 3))
            {
                case 1:
                    path += ".xml";
                    if (LoadOrganization(path, new XMLManager()))
                        Console.WriteLine($"Файл {path} загружен");
                    else Console.WriteLine($"Ошибка загрузки файла {path}!!!");
                    break;
                case 2:
                    path += ".json";
                    if (LoadOrganization(path, new JSONManager()))
                        Console.WriteLine($"Файл {path} загружен");
                    else Console.WriteLine($"Ошибка загрузки файла {path}!!!");
                    break;
                case 3:
                    break;
            }
            Console.ReadKey();
            SelectedDepartment = null;
            StackDepart.Clear();
        }
        public bool SaveOrganization(string path, FileManager FM)
        {
            if (FM.Save(path, Organization))
                return true;
            else return false;
        }
        public bool LoadOrganization(string path, FileManager FM)
        {
            Organization org;
            if (FM.Load(path, out org))
            {
                Organization = org;
                return true;
            }
            else return false;
        }
        private int InsertInt(int min, int max)
        {
            int number;
            int posX = Console.CursorLeft, posY = Console.CursorTop;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number))
                    if (number >= min && number <= max)
                    {
                        break;
                    }

                Console.SetCursorPosition(posX, posY);
                Console.WriteLine(new StringBuilder().Append(' ', Console.LargestWindowWidth - 1));
                Console.SetCursorPosition(posX, posY);
            }
            return number;
        }

    }
}
