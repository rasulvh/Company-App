using Domain.Models;
using Repository.Data;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Company_App.Controller
{
    public class EmployeeController
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
        }

        public void Add()
        {
            if (_departmentService.Count() == 0)
            {
                ConsoleColor.Red.WriteConsole("Before creating employee please create a department");
                return;
            }

            try
            {
                Employee employee = new Employee();

                ConsoleColor.DarkYellow.WriteConsole("For which department would you like to add employee (write departament id): ");
            EmpDepartment: string departmentIdStr = Console.ReadLine();
                int departmentId;
                bool isParseDepartamentId = int.TryParse(departmentIdStr, out departmentId);

                if (isParseDepartamentId)
                {
                    if (_departmentService.GetById(departmentId) == null)
                    {
                        ConsoleColor.Red.WriteConsole("No department found for this id, please try again: ");
                        goto EmpDepartment;
                    }

                    if (_employeeService.GetByDepartmentId(departmentId).Count < _departmentService.GetById(departmentId).Capacity)
                    {
                        employee.Department = _departmentService.GetById(departmentId);
                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("Department capacity is full, please create new department\n");
                        return;
                    }
                    
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please write id correctly: ");
                    goto EmpDepartment;
                }

                ConsoleColor.DarkYellow.WriteConsole("Add employee name: ");
            EmpName: string name = Console.ReadLine().Replace(" ","");

                if (name == string.Empty || !Regex.IsMatch(name, @"^[A-Z]{1}[a-z]{2,}$"))
                {
                    ConsoleColor.Red.WriteConsole("Enter employee name correctly: ");
                    goto EmpName;
                }


                ConsoleColor.DarkYellow.WriteConsole("Add employee surname: ");
            EmpSurname: string surname = Console.ReadLine().Replace(" ","");

                if (surname == string.Empty || !Regex.IsMatch(surname, @"^[A-Z]{1}[a-z]{2,}$"))
                {
                    ConsoleColor.Red.WriteConsole("Enter employee surname correctly: ");
                    goto EmpSurname;
                }

                ConsoleColor.DarkYellow.WriteConsole("Add employee age: ");
            EmpAge: string ageStr = Console.ReadLine();
                int age;
                bool isParseAge = int.TryParse(ageStr, out age);

                if (age < 18 || age > 70)
                {
                    ConsoleColor.Red.WriteConsole("Employee age must be greater than 18 and less than 70: ");
                    goto EmpAge;
                }

                ConsoleColor.DarkYellow.WriteConsole("Add employee address: ");
            EmpAddress: string address = Console.ReadLine();

                if (address == string.Empty || !Regex.IsMatch(address, @"([\w]{2,} *[0-9]*[.\-,]*[^~@#$%^&*()_+={}!\|:;'></?])+"))
                {
                    ConsoleColor.Red.WriteConsole("Enter employee address correctly: ");
                    goto EmpAddress;
                }

                employee.Name= name;
                employee.Age= age;
                employee.Address= address;
                employee.Surname= surname;
                

                _employeeService.Create(employee);
                ConsoleColor.Green.WriteConsole($"Employee Id: {employee.Id}, Name: {employee.Name}, Surname: {employee.Surname}, Age: {employee.Age}, Address: {employee.Address}, Department Id: {employee.Department.Id}");
                ConsoleColor.Green.WriteConsole("Successfully created");
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }

        public void Delete()
        {
            if (_employeeService.Count() == 0)
            {
                ConsoleColor.Red.WriteConsole("Before deletinig employee, create employee\n");
                return;
            }

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
                    var result = _employeeService.GetByAge(age);

                    foreach (var item in result)
                    {
                        ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname}, Age: {item.Age}, Address: {item.Address}, Department Id: {item.Department.Id}");
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
                goto Age;
            }
        }

        public void GetById()
        {
            ConsoleColor.DarkYellow.WriteConsole("Write employee id: ");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isParseId = int.TryParse(idStr, out id);

            var result = _employeeService.GetById(id);

            if (result is null)
            {
                ConsoleColor.Red.WriteConsole("No employee found for this id\n");
                return;
            }

            try
            {
                if (isParseId)
                {
                    ConsoleColor.Green.WriteConsole($"Employee Id: {result.Id}, Name: {result.Name}, Surname: {result.Surname}, Age: {result.Age}, Address: {result.Address}, Department Id: {result.Department.Id}");
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
                goto Id;
            }
        }

        public void GetAll()
        {
            try
            {
                foreach (var item in _employeeService.GetAll())
                {
                    ConsoleColor.Green.WriteConsole($"Employee Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname}, Age: {item.Age}, Address: {item.Address}, Department Id: {item.Department.Id}");
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
        Info: string info = Console.ReadLine();

            try
            {
                if (info is "")
                {
                    ConsoleColor.Red.WriteConsole("Please fill the line: ");
                    goto Info;
                }


                var result = _employeeService.Search(info);

                if (result.Count is 0)
                {
                    ConsoleColor.Red.WriteConsole("No employee found\n");
                    return;
                }

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

        public void GetByDepartmentName()
        {
            ConsoleColor.DarkYellow.WriteConsole("Write department name: ");
        Name: string name = Console.ReadLine();

            if (name is "")
            {
                ConsoleColor.Red.WriteConsole("Please fill the line: ");
                goto Name;
            }

            try
            {
                var result = _employeeService.GetByDepartmentName(name);

                if (result.Count is 0)
                {
                    ConsoleColor.Red.WriteConsole("No employee found for this department named like this\n");
                    return;
                }

                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole($"Employee Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname}, Age: {item.Age}, Address: {item.Address}, Department Name: {item.Department.Name}");
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Name;
            }
        }

        public void GetByDepartmentId()
        {
            ConsoleColor.DarkYellow.WriteConsole("Write department id: ");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isParseId = int.TryParse(idStr, out id);

            var checkDepartmentIsNull = _departmentService.GetById(id);

            if (checkDepartmentIsNull is null)
            {
                ConsoleColor.Red.WriteConsole("No department found for this id\n");
                return;
            }

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
            if (_employeeService.Count() == 0)
            {
                ConsoleColor.Red.WriteConsole("Before updeting employee, create employee\n");
                return;
            }

            ConsoleColor.DarkYellow.WriteConsole("Write employee id that you want to update: ");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isParseId = int.TryParse(idStr, out id);

            if (!isParseId)
            {
                ConsoleColor.Red.WriteConsole("Write id correctly: ");
                goto Id;
            }

            var res = _employeeService.GetById(id);

            if (res == null)
            {
                ConsoleColor.Red.WriteConsole("Employee not found, please enter correct id: ");
                goto Id;
            }

        DirectDepId: ConsoleColor.DarkYellow.WriteConsole("Enter new department id: ");
        DepId: string depIdStr = Console.ReadLine();
            int depId;
            bool isParseDepId = int.TryParse(depIdStr, out depId);

            if (depIdStr is null)
            {
                goto DirectName;
            }

            if (!isParseDepId)
            {
                ConsoleColor.Red.WriteConsole("Write department id correctly: ");
                goto DepId;
            }

            var result = _departmentService.GetById(depId);

            if (result == null)
            {
                ConsoleColor.Red.WriteConsole("No department found, please try again: ");
                goto DepId;
            }

            if (_employeeService.GetByDepartmentId(depId).Count <= _departmentService.GetById(depId).Capacity)
            {
                ConsoleColor.Red.WriteConsole("This department is full, please try another department\n");
                return;
            }

            ConsoleColor.DarkYellow.WriteConsole("If you don't want to update name, surname or address leave it empty, if you don't want to update age write 0\n");

        DirectName: ConsoleColor.DarkYellow.WriteConsole("Enter new employee name: ");
        Name: string name = Console.ReadLine().Replace(" ", "");

            try
            {
                if (name is "")
                {
                    goto DirectSurname;
                }
                if (!Regex.IsMatch(name, @"^[A-Z]{1}[a-z]+$"))
                {
                    ConsoleColor.Red.WriteConsole("Enter employee name correctly: ");
                    goto Name;
                }


            DirectSurname: ConsoleColor.DarkYellow.WriteConsole("Enter new employee surname: ");
            Surname: string surname = Console.ReadLine().Replace(" ", "");

                if (surname is "")
                {
                    goto DirectAddress;
                }
                if (!Regex.IsMatch(surname, @"^[A-Z]{1}[a-z]+$"))
                {
                    ConsoleColor.Red.WriteConsole("Enter employee surname correctly: ");
                    goto Surname;
                }


            DirectAddress: ConsoleColor.DarkYellow.WriteConsole("Enter new employee address: ");
            Address: string address = Console.ReadLine();

                if (address is "")
                {
                    goto DirectAge;
                }
                if (!Regex.IsMatch(address, @"([\w]{2,} *[0-9]*[.\-,]*[^@#$%/;:'><?*\^()_!])+"))
                {
                    ConsoleColor.Red.WriteConsole("Enter employee address correctly: ");
                    goto Address;
                }

            DirectAge: ConsoleColor.DarkYellow.WriteConsole("Enter new employee age: ");
            Age: string ageStr = Console.ReadLine();
                int age;
                bool isParseAge = int.TryParse(ageStr, out age);

                if (ageStr is "")
                {
                    goto DirectDepId;
                }
                if (!isParseAge)
                {
                    ConsoleColor.Red.WriteConsole("Enter employee age correctly: ");
                    goto Age;
                }

                var result2 = _departmentService.GetById(depId);

                bool isNameNull = string.IsNullOrEmpty(name);
                bool isSurnameNull = string.IsNullOrEmpty(surname);
                bool isAddressNull = string.IsNullOrEmpty(address);
                bool isAgeNull = string.IsNullOrEmpty(ageStr);
                bool isDepIdNull = string.IsNullOrEmpty(depIdStr);

                Employee employee1 = new Employee();

                if (!isNameNull)
                {
                    employee1.Name = name;
                }
                if (!isSurnameNull)
                {
                    employee1.Surname = surname;
                }
                if (!isAddressNull)
                {
                    employee1.Address = address;
                }
                if (!isAgeNull)
                {
                    employee1.Age = age;
                }
                if (!isDepIdNull)
                {
                    employee1.Department = result2;
                }

                _employeeService.Update(id, employee1);

                ConsoleColor.Green.WriteConsole("Successfully updated");
            }

            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }

        public int Count()
        {
            return _employeeService.Count();
        }
    }
}
