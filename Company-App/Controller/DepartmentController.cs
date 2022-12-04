using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            try
            {
                ConsoleColor.DarkYellow.WriteConsole("Write department id: ");
                string idStr = Console.ReadLine();
                int id;
                bool isParseId = int.TryParse((string)idStr, out id);

                if (isParseId) 
                {

                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }
    }
}
