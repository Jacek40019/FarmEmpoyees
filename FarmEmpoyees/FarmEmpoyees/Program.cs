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
                AddDataToFile();
                break;
            case "m":
            case "M":
                AddDataToMemory();
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


void AddDataToFile()
{
    Console.WriteLine($"\n--------------------------------------------------------------------------------------------");
    Console.WriteLine("Enter the employee's name:");
    var name = Console.ReadLine();
    Console.WriteLine("Enter the employee's surname:");
    var surname = Console.ReadLine();
    var employee = new EmployeeInFile(name, surname);
    //employee.SalaryAdded += InputSalaryData;

    InputSalaryData(employee);
    employee.GetStatistics();
    employee.ShowStatistics();


}

//void InputSalaryData(object sender, EventArgs args)
//{
//    throw new NotImplementedException();
//}

void AddDataToMemory()
{
    Console.WriteLine($"\n--------------------------------------------------------------------------------------------");
    Console.WriteLine("Enter the employee's name:");
    var name = Console.ReadLine();
    Console.WriteLine("Enter the employee's surname:");
    var surname = Console.ReadLine();
    var employee = new EmployeeInMemory(name, surname);
    //employee.SalaryAdded += InputSalaryData;

    InputSalaryData(employee);
    employee.GetStatistics();
    employee.ShowStatistics();

}



void InputSalaryData(IEmployee employee)
{

    var calculateSalary = new DataForCalculation();
    Console.WriteLine("\nEnter the weight of the harvested fruit in kilograms (e.g. 7,82) ");

    foreach (var fruit in calculateSalary.Fruits)
    {
        Console.WriteLine($"{fruit} [kg]: ");

        float salaryForFruit = 0;
        var weightOfFruit = Console.ReadLine();
        try
        {

            var weightOfFruitAsFloat = calculateSalary.ParseToFloat(weightOfFruit);


        }
        catch (Exception e)

        {
            Console.WriteLine($"{e.Message}");
            
        }
        finally
        {
            switch (fruit)
            {
                case "Apple":
                    salaryForFruit = weightOfFruitAsFloat * calculateSalary.RateKgApple;
                    Console.WriteLine($"saved {salaryForFruit:N2} PLN at the rate {calculateSalary.RateKgApple} per kilogram of {fruit}\n");
                    employee.AddSalary(salaryForFruit);
                    break;

                case "Strawberries":
                    salaryForFruit = weightOfFruitAsFloat * calculateSalary.RateKgStrawberries;
                    Console.WriteLine($"saved {salaryForFruit:N2} PLN at the rate {calculateSalary.RateKgStrawberries} per kilogram of {fruit}\n");
                    employee.AddSalary(salaryForFruit);
                    break;

                case "Grapes":
                    salaryForFruit = weightOfFruitAsFloat * calculateSalary.RateKgGrapes;
                    Console.WriteLine($"saved {salaryForFruit:N2} PLN at the rate {calculateSalary.RateKgGrapes} per kilogram of {fruit}\n");
                    employee.AddSalary(salaryForFruit);
                    break;

                case "Berries":
                    salaryForFruit = weightOfFruitAsFloat * calculateSalary.RateKgBerries;
                    Console.WriteLine($"saved {salaryForFruit:N2} PLN at the rate {calculateSalary.RateKgBerries} per kilogram of {fruit}\n");
                    employee.AddSalary(salaryForFruit);
                    break;
            }
        }
    }
}

void PrintInfo()
{
    var printInfo = new DataForCalculation();

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("------------------------------------ Salary information ------------------------------------");
    Console.WriteLine("Rates per kg of fruit:");
    Console.WriteLine($"1 kg of apples = {printInfo.RateKgApple} PLN");
    Console.WriteLine($"1 kg of strawberries = {printInfo.RateKgStrawberries} PLN");
    Console.WriteLine($"1 kg of grapes = {printInfo.RateKgGrapes} PLN");
    Console.WriteLine($"1 kg of berries = {printInfo.RateKgBerries} PLN");
    Console.WriteLine($"\nDayly working norm is {printInfo.DailyWorkingNorm} hours");
    Console.WriteLine($"Weekly working norm is {printInfo.WeeklyWorkingNorm} hours");
    Console.WriteLine($"Average hourly income {printInfo.StandardHourlyIncome} PLN");
    Console.WriteLine("--------------------------------------------------------------------------------------------");
    Console.ResetColor();
}
