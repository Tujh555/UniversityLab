using SusuLabs.Lab3.Domain.Employees;

namespace SusuLabs.Lab3.Utils;

/// <summary>
/// Класс отвечающий за запрос и парсинг данных сотрудника
/// </summary>
public class EmployeeParser
{
    private readonly EmployeeBuilder _builder = new();
    
    /// <summary>
    /// Результат создания сотрудника
    /// <seealso cref="ILiveData{T}"/>
    /// </summary>
    public ILiveData<Employee> CreationResult => _creationResult;
    private MutableLiveData<Employee> _creationResult = new();
    private bool _isFixedRateEmployee;

    /// <summary>
    /// Запрашивает данные о сотруднике, в случе удачи
    /// отправляет результат в CreationResult.
    /// </summary>
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

    /// <summary>
    /// Рекурсивно запрашивает данные с клавиатуры
    /// </summary>
    /// <param name="item">Номер операции запроса</param>
    /// <param name="action">Операция запроса</param>
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

    /// <summary>
    /// Запрашивает название профессии
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
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

    /// <summary>
    /// Запрашивает сумму премии
    /// </summary>
    private void RequestAward()
    {
        Console.WriteLine("Введите премию");
        var num = double.Parse(Console.ReadLine()!);
        _builder.Award(num);
    }

    /// <summary>
    /// Запрашивает фиксированную ставку
    /// </summary>
    private void RequestFixedRate()
    {
        Console.WriteLine("Введите фиксированную оплату");
        var num = double.Parse(Console.ReadLine()!);
        _builder.FixedRate(num);
    }

    /// <summary>
    /// Запрашивает почасовую оплату
    /// </summary>
    private void RequestHourlyRate()
    {
        Console.WriteLine("Введите почасовую оплату");
        var num = double.Parse(Console.ReadLine()!);
        _builder.HourlyRate(num);
    }

    /// <summary>
    /// Запрашивает имя сотрудника
    /// </summary>
    private void RequestName()
    {
        Console.WriteLine("Введите имя сотрудника");

        var name = Console.ReadLine() ?? "";
        _builder.Name(name);
    }

    /// <summary>
    /// Запрашивает дату рождения сотрудника в формате гггг.мм.дд
    /// </summary>
    private void RequestBornDate()
    {
        Console.WriteLine("Введите дату рождения (гггг.мм.дд)");

        var arr = Console.ReadLine()!.Split(".").Select(int.Parse).ToArray();

        _builder.BornDate(arr);
    }
}