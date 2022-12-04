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
    public class EmployeeController
    {
        Employee employee = new Employee();
        private readonly DepartmentService _departmentService;

        public EmployeeController()
        {
            _departmentService= new DepartmentService();
        }

        public void Add()
        {
            try
            {
                ConsoleColor.DarkYellow.WriteConsole("Add employee name: ");
            EmpName: string name = Console.ReadLine();

                if (name is "")
                {
                    ConsoleColor.Red.WriteConsole("Employee name cannot be empty: ");
                    goto EmpName;
                }

                ConsoleColor.DarkYellow.WriteConsole("Add employee surname: ");
            EmpSurname: string surname = Console.ReadLine();

                if (surname is "")
                {
                    ConsoleColor.Red.WriteConsole("Employee surname cannot be empty: ");
                    goto EmpSurname;
                }

                ConsoleColor.DarkYellow.WriteConsole("Add employee age: ");
            EmpAge: string ageStr = Console.ReadLine();
                int age;
                bool isParseAge = int.TryParse(ageStr, out age);

                if (age < 20)
                {
                    ConsoleColor.Red.WriteConsole("Employee age must be greater thatn 20: ");
                    goto EmpAge;
                }

                ConsoleColor.DarkYellow.WriteConsole("Add employee address: ");
            EmpAddress: string address = Console.ReadLine();

                if (address is "")
                {
                    ConsoleColor.Red.WriteConsole("Employee address cannot be empty: ");
                    goto EmpAddress;
                }

                ConsoleColor.DarkYellow.WriteConsole("For which department would you like to add employee (write departament id): ");
            EmpDepartment: string departmentIdStr = Console.ReadLine();
                int departmentId;
                bool isParseDepartamentId = int.TryParse(departmentIdStr, out departmentId);

                if (isParseDepartamentId)
                {
                    ConsoleColor.Green.WriteConsole("Employee was successfully added");

                    employee.Name = name;
                    employee.Address = address;
                    employee.Surname = surname;
                    employee.Age= age;
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }
    }
}
