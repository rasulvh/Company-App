using Company_App.Controller;
using Service.Helpers;

Menus();





static void Menus()
{
    DepartmentController departmentController = new DepartmentController();
    EmployeeController employeeController = new EmployeeController();

    while (true)
    {
        ConsoleColor.Cyan.WriteConsole("Select one option");
        Console.WriteLine("-----------------");
        ConsoleColor.Cyan.WriteConsole("Department options: 1.Create, 2.Delete, 3.Update, 4.Get department by id, 5.Get all, 6.Search");
        ConsoleColor.Cyan.WriteConsole("Employee options: 7.Create, 8.Delate, 9.Update, 10.Get by age, 11.Get by id, 12.Get by department id, 13.Get all by department name, 14.Search, 15.Get count");

        Option:  string optionStr = Console.ReadLine();
        int option;
        bool isParseOption = int.TryParse(optionStr, out option);

        if (isParseOption)
        {
            switch (option)
            {
                case 1:
                    departmentController.Create();
                    break;
                case 2:
                    departmentController.Delete();
                    break;
                case 3:
                    break;
                case 4:
                    departmentController.GetById();
                    break;
                case 5:
                    departmentController.GetAll();
                    break;
                case 6:
                    departmentController.Search();
                    break;
                case 7:
                    employeeController.Add();
                    break;
                case 8:
                    employeeController.Delete();
                    break;
                case 9:
                    break;
                case 10:
                    employeeController.GetByAge();
                    break;
                case 11:
                    employeeController.GetById();
                    break;
                case 12:
                    break;
                case 13:
                    employeeController.GetByDepartmentName();
                    break;
                case 14:
                    employeeController.Search();
                    break;
                case 15:
                    break;
                default:
                    ConsoleColor.Red.WriteConsole("Please select true option: ");
                    goto Option;
            }
        }
        else
        {
            ConsoleColor.Red.WriteConsole("Please select true option: ");
            goto Option;
        }
    }
}