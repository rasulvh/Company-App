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
                string name = Console.ReadLine();

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
    }
}
