using SusuLabs.Lab3.Domain.Employees;

namespace SusuLabs.Lab3.Utils;

public class EmployeeParser
{
    private readonly EmployeeBuilder _builder = new();
    
    public ILiveData<Employee> CreationResult => _creationResult;
    private MutableLiveData<Employee> _creationResult = new();
    private bool _isFixedRateEmployee;

    public void Parse()
    {
        try
        {
            RequestItem(0, RequestName);
            _creationResult.Value = _builder.Build();
        }
        catch (Exception _)
        {
            Console.WriteLine("Введены некорректные данные");
        }
    }

    private void RequestItem(int item, Action action)
    {
        action();

        switch (item)
        {
            case 0: RequestItem(1, RequestBornDate); break;
            case 1: RequestItem(2, RequestJobTitle); break;
            case 2: RequestItem(3, _isFixedRateEmployee ? RequestFixedRate : RequestHourlyRate); break;
            case 3: RequestItem(4, RequestAward); break;
        }
    }

    private void RequestJobTitle()
    {
        Console.WriteLine("Введите номер должности");
        Console.WriteLine("1. Программист (фиксированная оплата)\n" +
                          "2. Секретарь (фиксированная оплата)\n" +
                          "3. Системный администратор (фиксированная оплата)\n" +
                          "4. Уборщик (почасовая оплата)\n" +
                          "5. Кассир (почасовая оплата)\n" +
                          "6. Курьер (почасовая оплата)");

        if (int.TryParse(Console.ReadLine()!, out var jobTitleNumber) && jobTitleNumber >= 1 && jobTitleNumber <= 6)
        {
            _builder.JobTitle(
                jobTitleNumber switch
                {
                    1 => EmployeeJobTitle.Programmer.Also(_ => _isFixedRateEmployee = true),
                    2 => EmployeeJobTitle.Secretary.Also(_ => _isFixedRateEmployee = true),
                    3 => EmployeeJobTitle.SystemAdministrator.Also(_ => _isFixedRateEmployee = true),
                    4 => EmployeeJobTitle.Cleaner.Also(_ => _isFixedRateEmployee = false),
                    5 => EmployeeJobTitle.Cashier.Also(_ => _isFixedRateEmployee = false),
                    6 => EmployeeJobTitle.Courier.Also(_ => _isFixedRateEmployee = false),
                    _ => throw new ArgumentOutOfRangeException("")
                }
            );
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ввёден некорректный номер");
            Console.ResetColor();
        }
    }

    private void RequestAward()
    {
        Console.WriteLine("Введите премию");
        var num = double.Parse(Console.ReadLine()!);
        _builder.Award(num);
    }

    private void RequestFixedRate()
    {
        Console.WriteLine("Введите фиксированную оплату");
        var num = double.Parse(Console.ReadLine()!);
        _builder.FixedRate(num);
    }

    private void RequestHourlyRate()
    {
        Console.WriteLine("Введите почасовую оплату");
        var num = double.Parse(Console.ReadLine()!);
        _builder.HourlyRate(num);
    }

    private void RequestName()
    {
        Console.WriteLine("Введите имя сотрудника");

        var name = Console.ReadLine() ?? "";
        _builder.Name(name);
    }

    private void RequestBornDate()
    {
        Console.WriteLine("Введите дату рождения (гггг.мм.дд)");

        var arr = Console.ReadLine()!.Split(".").Select(int.Parse).ToArray();

        _builder.BornDate(arr);
    }
}