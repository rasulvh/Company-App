using Company_App.Controller;
using Service.Helpers;

Menus();





static void Menus()
{
    DepartmentController departmentController = new DepartmentController();
    EmployeeController employeeController = new EmployeeController();

    while (true)
    {
        DirectStart: ConsoleColor.DarkBlue.WriteConsole("Select one option");
        ConsoleColor.Red.WriteConsole("-----------------");
        ConsoleColor.DarkBlue.WriteConsole("Department options:\n" +
            "1.Create\n" +
            "2.Delete\n" +
            "3.Update\n" +
            "4.Get department by id\n" +
            "5.Get all\n" +
            "6.Search\n");
        ConsoleColor.DarkBlue.WriteConsole("Employee options:\n" +
            "7.Create\n" +
            "8.Delate\n" +
            "9.Update\n" +
            "10.Get by age\n" +
            "11.Get by id\n" +
            "12.Get by department id\n" +
            "13.Get all by department name\n" +
            "14.Get all\n" +
            "15.Search\n" +
            "16.Get count\n");

        ConsoleColor.DarkRed.WriteConsole("If you want to exit press 0\n");

        Option:  string optionStr = Console.ReadLine();
        int option;
        bool isParseOption = int.TryParse(optionStr, out option);

        if (isParseOption)
        {
            switch (option)
            {
                case 0:
                    goto Exit;
                case 1:
                    departmentController.Create();
                    break;
                case 2:
                    departmentController.Delete();
                    break;
                case 3:
                    departmentController.Update();
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
                    employeeController.Update();
                    break;
                case 10:
                    employeeController.GetByAge();
                    break;
                case 11:
                    employeeController.GetById();
                    break;
                case 12:
                    employeeController.GetByDepartmentId();
                    break;
                case 13:
                    employeeController.GetByDepartmentName();
                    break;
                case 14:
                    employeeController.GetAll();
                    break;
                case 15:
                    employeeController.Search();
                    break;
                case 16:
                    employeeController.GetCount();
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

        goto DirectStart;
    Exit: break;
    }
}