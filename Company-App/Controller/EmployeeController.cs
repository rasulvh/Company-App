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
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;

        public EmployeeController()
        {
            _employeeService= new EmployeeService();
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

                if (age < 18)
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
                    Employee employee = new Employee()
                    {
                        Name = name,
                        Age = age,
                        Surname = surname,
                        Address= address,
                        Department = _departmentService.GetById(departmentId)
                    };

                    _employeeService.Create(employee);
                    ConsoleColor.Green.WriteConsole($"Employee Id: {employee.Id}, Name: {employee.Name}, Surname: {employee.Surname}, Age: {employee.Age}, Address: {employee.Address}, Department Id: {employee.Department.Id}");
                }
                else 
                {
                    ConsoleColor.Red.WriteConsole("Please write id correctly: ");
                    goto EmpDepartment;
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }

        public void Delete()
        {
            ConsoleColor.DarkYellow.WriteConsole("Write employee id: ");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isParseId = int.TryParse(idStr, out id);

            try
            {
                if (isParseId)
                {
                    _employeeService.Delete(id);

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

        public void GetByAge()
        {
            ConsoleColor.DarkYellow.WriteConsole("Write employee age: ");
        Age: string ageStr = Console.ReadLine();
            int age;
            bool isParseAge = int.TryParse(ageStr, out age);

            try
            {
                if (isParseAge)
                {
                    foreach (var item in _employeeService.GetByAge(age))
                    {
                        ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname}, Age: {item.Age}, Address: {item.Address}, Department Id: {item.Department}");
                    }
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please write correct age: ");
                    goto Age;
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }

        public void GetById()
        {
            ConsoleColor.DarkYellow.WriteConsole("Write employee id: ");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isParseId = int.TryParse(idStr, out id);
            
            try
            {
                if (isParseId)
                {
                    var result = _employeeService.GetById(id);

                    ConsoleColor.Green.WriteConsole($"Employee Id: {result.Id}, Name: {result.Name}, Surname: {result.Surname}, Age: {result.Age}, Address{result.Address}, Department Id: {result.Department.Id}");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please write id correctly: ");
                    goto Id;
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }

        public void Search()
        {
            ConsoleColor.DarkYellow.WriteConsole("Write employee name or surname: ");
            string info = Console.ReadLine();

            try
            {
                var result = _employeeService.Search(info);

                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole($"Employee Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname}, Age: {item.Age}, Address{item.Address}, Department Id: {item.Department.Id}");
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }

        public void GetByDepartmentName()
        {
            ConsoleColor.DarkYellow.WriteConsole("Write department name: ");
            string name = Console.ReadLine();

            try
            {
                var result = _employeeService.Search(name);

                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole($"Employee Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname}, Age: {item.Age}, Address: {item.Address}, Department Id: {item.Department.Id}");
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }

        public void GetByDepartmentId()
        {
            ConsoleColor.DarkYellow.WriteConsole("Write department id: ");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isParseId = int.TryParse(idStr, out id);

            try
            {
                if (isParseId)
                {
                    var result = _employeeService.GetByDepartmentId(id);

                    foreach (var item in result)
                    {
                        ConsoleColor.Green.WriteConsole($"Employee Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname}, Age: {item.Age}, Address: {item.Address}, Department Id: {item.Department.Id}");
                    }
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
            }
        }

        public void GetCount()
        {
            try
            {
                ConsoleColor.Green.WriteConsole($"Count: {_employeeService.Count()}");
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }

        public void Update()
        {
            ConsoleColor.DarkYellow.WriteConsole("Write employee id that you want to update: ");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isParseId = int.TryParse(idStr, out id);

            try
            {
                ConsoleColor.DarkYellow.WriteConsole("Enter new employee name: ");
                string name = Console.ReadLine();

                ConsoleColor.DarkYellow.WriteConsole("Enter new employee surname: ");
                string surname = Console.ReadLine();

                ConsoleColor.DarkYellow.WriteConsole("Enter new employee age: ");
            Capacity: string ageStr = Console.ReadLine();
                int age;
                bool isParseAge = int.TryParse(ageStr, out age);

                ConsoleColor.DarkYellow.WriteConsole("Enter new employee address: ");
                string address = Console.ReadLine();


                if (!isParseAge)
                {
                    ConsoleColor.Red.WriteConsole("Write age correctly");
                    goto Capacity;
                }

                _employeeService.GetById(id).Name = name;
                _employeeService.GetById(id).Surname = surname;
                _employeeService.GetById(id).Age = age;
                _employeeService.GetById(id).Address = address;


                Employee employee = new()
                {
                    Name = name,
                    Surname = surname,
                    Age = age,
                    Address = address
                };

                _employeeService.Update(employee);

                ConsoleColor.Green.WriteConsole($"Employee Id : {_employeeService.GetById(id).Id}, Employee Name : {_employeeService.GetById(id).Name}, Employee Surname: {_employeeService.GetById(id).Surname},Employee Age: {_employeeService.GetById(id).Age}, Employee Address: {_employeeService.GetById(id).Address}");
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }
    }
}
