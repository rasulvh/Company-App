using Company_App.Controller;
using Service.Helpers;

Menus();





static void Menus()
{
    DepartmentController departmentController = new DepartmentController();

    while (true)
    {
        ConsoleColor.Cyan.WriteConsole("Select one option: ");
        ConsoleColor.Cyan.WriteConsole("Department options: 1.Create");

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