using SusuLabs.Lab3.Domain.Employees.FixedSalary;
using SusuLabs.Lab3.Domain.Employees.HourlySalary;

namespace SusuLabs.Lab3.Domain.Employees;

/// <summary>
/// Класс используется для пошагового создания сотрудников
/// </summary>
public class EmployeeBuilder
{
    private readonly HashSet<int> _idSet = new();
    private string _name = "";
    private DateTime _bornDate;
    private double _hourlyRate = 100.0;
    private double _fixedRate = 20_000.0;
    private double _award;
    private EmployeeJobTitle? _jobTitle;
    private int? _id;

    /// <summary>
    /// Возвращает новый айди, уникальный для данного экземпляра
    /// </summary>
    /// <returns></returns>
    private int GetNewId()
    {
        int newId;

        do
        {
            newId = Random.Shared.Next();
        } while (_idSet.Contains(newId));

        _idSet.Add(newId);

        return newId;
    }

    public EmployeeBuilder Id(int id)
    {
        _id = id;
        _idSet.Add(id);
        return this;
    }

    public EmployeeBuilder Name(string name)
    {
        _name = name;
        return this;
    }

    /// <summary>
    /// Устанавливает дату рождения пользоватедя
    /// </summary>
    /// <param name="date">Дата рождения в формате гггг.мм.дд</param>
    /// <returns></returns>
    public EmployeeBuilder BornDate(params int[] date)
    {
        var newDate = new[] { 0, 0, 0 };

        for (int i = 0; i < Math.Min(date.Length, newDate.Length); i++)
        {
            newDate[i] = date[i];
        }

        _bornDate = new DateTime(newDate[0], newDate[1], newDate[2]);
        return this;
    }

    public EmployeeBuilder BornDate(DateTime date)
    {
        _bornDate = date;
        return this;
    }

    public EmployeeBuilder HourlyRate(double rate)
    {
        _hourlyRate = rate;
        return this;
    }

    public EmployeeBuilder FixedRate(double rate)
    {
        _fixedRate = rate;
        return this;
    }

    public EmployeeBuilder Award(double award)
    {
        _award = award;
        return this;
    }

    public EmployeeBuilder JobTitle(EmployeeJobTitle title)
    {
        _jobTitle = title;
        return this;
    }

    /// <summary>
    /// Создаёт новый экземпляр сотрудника
    /// </summary>
    /// <returns>Сотрудник фирмы</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <seealso cref="Employee"/>
    public Employee Build()
    {
        var jobTitle = _jobTitle ?? throw new ArgumentException("Unknown type of job title");
        
        return _jobTitle switch
        {
            EmployeeJobTitle.Cashier => new Cashier(_id ?? GetNewId(), _name, _bornDate, _hourlyRate, _award, jobTitle),
            EmployeeJobTitle.Cleaner => new Cleaner(_id ?? GetNewId(), _name, _bornDate, _hourlyRate, _award, jobTitle),
            EmployeeJobTitle.Courier => new Courier(_id ?? GetNewId(), _name, _bornDate, _hourlyRate, _award, jobTitle),
            EmployeeJobTitle.Programmer => new Programmer(_id ?? GetNewId(), _name, _bornDate, _fixedRate, _award, jobTitle),
            EmployeeJobTitle.Secretary => new Secretary(_id ?? GetNewId(), _name, _bornDate, _fixedRate, _award, jobTitle),
            EmployeeJobTitle.SystemAdministrator => new SystemAdministrator(_id ?? GetNewId(), _name, _bornDate, _fixedRate, _award, jobTitle),
            _ => throw new ArgumentException("Unknown type of job title")
        };
    }
}

/// <summary>
/// Перечисление рабочих должностей
/// </summary>
public enum EmployeeJobTitle
{
    Secretary, Programmer, SystemAdministrator, Cleaner, Courier, Cashier
}