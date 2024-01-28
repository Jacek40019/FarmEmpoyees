// Application for calculating payments of fruit plantation employees

using FarmEmployees;

using static FarmEmployees.EmployeeBase;

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("                              FarmEmployees - payroll");
Console.WriteLine("--------------------------------------------------------------------------------------------");
Console.ResetColor();

Console.WriteLine("\n<i> - info. rates per kilo /  standard working time");
Console.WriteLine("<q> - exit");
Console.WriteLine("<any key> - enter salary data");
Console.WriteLine("\nplease enter your choice:");


while (true)
{
    var input = Console.ReadLine();
    if (input == "q" || input == "Q")
    {
        break;
    }
    else if (input == "i" || input == "I")
    {
        PrintInfo();
    }
    else
    {
        Console.WriteLine("Now you will enter the data needed to calculate the salary. \nDo you want to save the data in a file or memory?");
        Console.WriteLine("<f> - save to file  \n<m> - save to memory \n<q> - exit");
        var fileOrMemory = Console.ReadLine();

        switch (fileOrMemory)
        {
            case "f":
            case "F":
                AddData(true); // StudentInFile
                break;
            case "m":
            case "M":
                AddData(false); // StudentInMemory
                break;
            case "q":
            case "Q":
                break;
            default:
                Console.WriteLine("<f> - save to file \n<m> - save to memory \n<q> - exit");
                continue;
        }

    }
}
Console.WriteLine("### Thank you for using my App ###");


void AddData(bool isInFile)
{
    Console.WriteLine($"\n--------------------------------------------------------------------------------------------");
    Console.WriteLine("Enter the employee's name:");

    string name = null;
    while (string.IsNullOrWhiteSpace(name))
    {
        name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty. Please enter a valid name:");
        }
    }

    Console.WriteLine("Enter the employee's surname:");

    string surname = null;
    while (string.IsNullOrWhiteSpace(surname))
    {
        surname = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(surname))
        {
            Console.WriteLine("Surname cannot be empty. Please enter a valid surname:");
        }
    }

    IEmployee employee = isInFile ? new EmployeeInFile(name, surname) : new EmployeeInMemory (name, surname);

    employee.SalaryAdded += SalaryAddedInfo;
    InputSalaryData(employee);
    employee.GetStatistics();
    employee.ShowStatistics();

    void SalaryAddedInfo(object sender, EventArgs argse)
    {
        Console.WriteLine("Salary saved");
    }
}

void InputSalaryData(IEmployee employee)
{

    float rateKgFruit = 0;
    float salaryForFruit = 0;

    Console.WriteLine("\nEnter the weight of the harvested fruit in kilograms (e.g. 7,82) ");

    foreach (var fruit in DataForCalculation.Fruits)
    {

        Console.WriteLine($"{fruit} [kg]: ");

        var weightOfFruit = Console.ReadLine();
        float weightOfFruitAsFloat = 0;

        try
        {
            weightOfFruitAsFloat = DataForCalculation.ParseToFloat(weightOfFruit);
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
        }

        switch (fruit)
        {

            case "Apple":
                rateKgFruit = DataForCalculation.RateKgApple;
                break;

            case "Strawberries":
                rateKgFruit = DataForCalculation.RateKgStrawberries;
                break;

            case "Grapes":
                rateKgFruit = DataForCalculation.RateKgGrapes;
                break;

            case "Berries":
                rateKgFruit = DataForCalculation.RateKgBerries;
                break;
        }

        try
        {
            salaryForFruit = weightOfFruitAsFloat * rateKgFruit;
            employee.AddSalary(salaryForFruit);

            switch (salaryForFruit)
            {
                case 0f:
                    Console.WriteLine($"saved {salaryForFruit:N2}\n");
                    break;
                default:
                    Console.WriteLine($"saved {salaryForFruit:N2} PLN at the rate {rateKgFruit} per kilogram of {fruit}\n");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
            salaryForFruit = 0;
            Console.WriteLine($"saved {salaryForFruit:N2}\n");
        }
    }
}

void PrintInfo()
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("------------------------------------ Salary information ------------------------------------");
    Console.WriteLine("Rates per kg of fruit:");
    Console.WriteLine($"1 kg of apples = {DataForCalculation.RateKgApple} PLN");
    Console.WriteLine($"1 kg of strawberries = {DataForCalculation.RateKgStrawberries} PLN");
    Console.WriteLine($"1 kg of grapes = {DataForCalculation.RateKgGrapes} PLN");
    Console.WriteLine($"1 kg of berries = {DataForCalculation.RateKgBerries} PLN");
    Console.WriteLine($"\nDayly working norm is {DataForCalculation.DailyWorkingNorm} hours");
    Console.WriteLine($"Weekly working norm is {DataForCalculation.WeeklyWorkingNorm} hours");
    Console.WriteLine($"Hourly income norm is {DataForCalculation.StandardHourlyIncome} PLN");
    Console.WriteLine("--------------------------------------------------------------------------------------------");
    Console.ResetColor();
}