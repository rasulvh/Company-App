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

            string searchText = Console.ReadLine();

            var result = _departmentService.Search(searchText);

            foreach (var item in result)
            {
                ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Seat count: {item.Capacity}");
            }
        }

        public void Update()
        {
            Department department = new Department();

            ConsoleColor.DarkYellow.WriteConsole("Write department id that you want to update: ");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isParseId = int.TryParse(idStr, out id);

            ConsoleColor.DarkYellow.WriteConsole("If you don't want to update name leave it empty, if you don't want to update capacity write 0: ");

            if (!isParseId)
            {
                ConsoleColor.Red.WriteConsole("Please write id correctly: ");
                goto Id;
            }

            try
            {
                if (_departmentService.GetById(id) == null)
                {
                    ConsoleColor.Red.WriteConsole("Department not found, please try again: ");
                    goto Id;
                }

                ConsoleColor.DarkYellow.WriteConsole("Enter new department name: ");
                string name = Console.ReadLine();
                ConsoleColor.DarkYellow.WriteConsole("Enter new department capacity: ");
                Capacity: string capacityStr = Console.ReadLine();
                int capacity;
                bool isParseCapacity = int.TryParse(capacityStr, out capacity);

                if (!isParseCapacity)
                {
                    ConsoleColor.Red.WriteConsole("Write capacity correctly");
                    goto Capacity;
                }

                //Update edende name-i update edende capacity update olunmur

                if (name != "")
                {
                    _departmentService.GetById(id).Name = name;
                    department.Name= name;
                }

                if (capacity != 0)
                {
                    _departmentService.GetById(id).Capacity = capacity;
                    department.Capacity = capacity;

                    _departmentService.Update(department);
                }

                ConsoleColor.Green.WriteConsole($"Department Id : {_departmentService.GetById(id).Id}, Department Name : {_departmentService.GetById(id).Name}, Department Capacity: {_departmentService.GetById(id).Capacity}");
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }
    }
}
