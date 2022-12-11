using Domain.Models;
using Service.Helpers;
using Service.Services;
using System.Net;

namespace Company_App.Controller
{
    public class DepartmentController
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController()
        {
            _departmentService= new DepartmentService();
        }

        public void Create()
        {
            try
            {
                ConsoleColor.DarkYellow.WriteConsole("Add department name: ");
                DepName: string name = Console.ReadLine();

                if (name is "")
                {
                    ConsoleColor.Red.WriteConsole("Department name cannot be empty: ");
                    goto DepName;
                }

                ConsoleColor.DarkYellow.WriteConsole("Add department capacity: ");
                Capacity:  string capacityStr = Console.ReadLine();
                int capacity;
                bool isParseCapacity = int.TryParse(capacityStr, out capacity);

                if (isParseCapacity)
                {
                    if (capacity < 1)
                    {
                        ConsoleColor.Red.WriteConsole("Capacity must be at least 1, please try again: ");
                        goto Capacity;
                    }

                    Department department = new()
                    {
                        Name = name,
                        Capacity = capacity
                    };


                    var result = _departmentService.Create(department);

                    ConsoleColor.Green.WriteConsole($"Department Id : {result.Id}, Department Name : {result.Name}, Department Capacity: {result.Capacity}");

                    ConsoleColor.Green.WriteConsole("Successfully created");
                }
                else 
                {
                    ConsoleColor.Red.WriteConsole("Please add correct capacity: ");
                    goto Capacity;
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }

        public void Delete()
        {
            ConsoleColor.DarkYellow.WriteConsole("Write department id: ");
        Id: string idStr = Console.ReadLine();

            try
            {

                int id;
                bool isParseId = int.TryParse(idStr, out id);

                if (isParseId) 
                {
                    _departmentService.Delete(id);

                    ConsoleColor.Green.WriteConsole("Successfully deleted");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please write correct id: ");
                    goto Id;
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Id;
            }
        }

        public void GetById()
        {
            ConsoleColor.DarkYellow.WriteConsole("Write department id: ");
        Id: string idStr = Console.ReadLine();

            try
            {
                int id;
                bool isParseId = int.TryParse((string)idStr, out id);

                if (isParseId) 
                {
                    var result = _departmentService.GetById(id);

                    if (result is null)
                    {
                        ConsoleColor.Red.WriteConsole("Department not found, please try again: ");
                        goto Id;
                    }

                    ConsoleColor.Green.WriteConsole($"Department Id : {result.Id}, Department Name : {result.Name}, Department Capacity: {result.Capacity}");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please write correctly: ");
                    goto Id;
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }

        public void GetAll()
        {
            try
            {
                foreach (var item in _departmentService.GetAll())
                {
                    ConsoleColor.Green.WriteConsole($"Department Id : {item.Id}, Department Name : {item.Name}, Department Capacity: {item.Capacity}");
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }

        public void Search()
        {
            ConsoleColor.DarkYellow.WriteConsole("Add department name: ");

            strText: string searchText = Console.ReadLine();

            if (searchText is "")
            {
                ConsoleColor.Red.WriteConsole("Please fill the line: ");
                goto strText;
            }

            var result = _departmentService.Search(searchText);

            foreach (var item in result)
            {
                ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Capacity: {item.Capacity}");
            }
        }

        public void Update()
        {
            ConsoleColor.DarkYellow.WriteConsole("Write department id that you want to update: ");
            Id: string idStr = Console.ReadLine();
            int id;
            bool isParseId = int.TryParse(idStr, out id);

            if (!isParseId)
            {
                ConsoleColor.Red.WriteConsole("Please write id correctly: ");
                goto Id;
            }

            ConsoleColor.DarkYellow.WriteConsole("If you don't want to update name or capacity leave it empty: ");

            try
            {
                if (_departmentService.GetById(id) == null)
                {
                    ConsoleColor.Red.WriteConsole("Department not found, please try again: ");
                    goto Id;
                }

                ConsoleColor.DarkYellow.WriteConsole("Enter new department name: ");
                Name: string name = Console.ReadLine();
                ConsoleColor.DarkYellow.WriteConsole("Enter new department capacity: ");
                Capacity: string capacityStr = Console.ReadLine();
                int capacity;
                bool isParseCapacity = int.TryParse(capacityStr, out capacity);

                if (capacityStr == "")
                {
                    goto DirectCapacity;
                }
                if (!isParseCapacity)
                {
                    ConsoleColor.Red.WriteConsole("Write capacity correctly: ");
                    goto Capacity;
                }

                DirectCapacity:

                Department department = _departmentService.GetById(id);

                if (name == null || name == string.Empty)
                {
                    if (capacityStr == "")
                    {
                        ConsoleColor.Green.WriteConsole($"Department Id : {_departmentService.GetById(id).Id}, Department Name : {_departmentService.GetById(id).Name}, Department Capacity: {_departmentService.GetById(id).Capacity}");
                    }
                    else if (capacityStr != "")
                    {
                        _departmentService.GetById(id).Capacity = capacity;

                        ConsoleColor.Green.WriteConsole($"Department Id : {_departmentService.GetById(id).Id}, Department Name : {_departmentService.GetById(id).Name}, Department Capacity: {_departmentService.GetById(id).Capacity}");

                        _departmentService.Update(department);
                    }
                }
                else if (name != null || name != string.Empty)
                {
                    _departmentService.GetById(id).Name = name;

                    if (capacityStr == "")
                    {
                        ConsoleColor.Green.WriteConsole($"Department Id : {_departmentService.GetById(id).Id}, Department Name : {_departmentService.GetById(id).Name}, Department Capacity: {_departmentService.GetById(id).Capacity}");
                    }
                    else if (capacityStr != "")
                    {
                        _departmentService.GetById(id).Capacity = capacity;

                        ConsoleColor.Green.WriteConsole($"Department Id : {_departmentService.GetById(id).Id}, Department Name : {_departmentService.GetById(id).Name}, Department Capacity: {_departmentService.GetById(id).Capacity}"); 

                        _departmentService.Update(department);
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }

        public int GetCount()
        {
            return _departmentService.Count();
        }
    }
}
