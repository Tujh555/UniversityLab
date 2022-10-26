using SusuLabs.Lab3.Domain.Employees;
using SusuLabs.Lab3.Presentation.Menu;
using SusuLabs.Lab3.Utils;

namespace SusuLabs.Lab3.Presentation;

public class EmployeeCreationMenu : BaseMenu
{
    private readonly EmployeeBuilder _builder = new();
    private bool _isFixedRateEmployee;
    private MutableLiveData<Employee> _liveData = new();

    public LiveData<Employee> EmployeeLiveData => _liveData;

    public EmployeeCreationMenu(string[] menuItems) : base(menuItems)
    {
    }

    protected override void DrawInput()
    {
        try
        {
            RequestItem(0, RequestName);
        }
        catch (Exception e)
        {
            Console.WriteLine("Введены некорректные данные");
        }

        _liveData.Value = _builder.Build();
        Console.WriteLine("Для выхода нажмите e");
    }

    private void RequestItem(int item, Action action)
    {
        action.Invoke();

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
                    6 => EmployeeJobTitle.Courier.Also(_ => _isFixedRateEmployee = false)
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