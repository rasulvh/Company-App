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
        ConsoleColor.Cyan.WriteConsole("Employee options: 7.Create, 8.Delate, 9.Update, 10.Get by age");

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
                case 10:
                    employeeController.GetByAge();
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