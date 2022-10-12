using SusuLabs.Lab3.Domain.Employees.FixedSalary;
using SusuLabs.Lab3.Domain.Employees.HourlySalary;

namespace SusuLabs.Lab3.Domain.Employees;

public class EmployeeBuilder
{
    private readonly HashSet<int> _idSet = new();
    private string _name;
    private DateTime _bornDate;
    private double _hourlyRate = 100.0;
    private double _fixedRate = 20_000.0;
    private double _award = 0.0;
    private EmployeeJobTitle _jobTitle = EmployeeJobTitle.Cleaner;

    private int GetNewId()
    {
        int newId;

        do
        {
            newId = Random.Shared.Next(200, 200);
        } while (_idSet.Contains(newId));

        _idSet.Add(newId);

        return newId;
    }

    public EmployeeBuilder Name(string name)
    {
        _name = name;
        return this;
    }

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

    public Employee Build() => _jobTitle switch
    {
        EmployeeJobTitle.Cashier => new Cashier(GetNewId(), _name, _bornDate, _hourlyRate, _award),
        EmployeeJobTitle.Cleaner => new Cleaner(GetNewId(), _name, _bornDate, _hourlyRate, _award),
        EmployeeJobTitle.Courier => new Courier(GetNewId(), _name, _bornDate, _hourlyRate, _award),
        EmployeeJobTitle.Programmer => new Programmer(GetNewId(), _name, _bornDate, _fixedRate, _award),
        EmployeeJobTitle.Secretary => new Secretary(GetNewId(), _name, _bornDate, _fixedRate, _award),
        EmployeeJobTitle.SystemAdministrator => new SystemAdministrator(GetNewId(), _name, _bornDate, _fixedRate, _award),
        _ => throw new ArgumentException("Unknown type of job title")
    };
}

public enum EmployeeJobTitle
{
    Secretary, Programmer, SystemAdministrator, Cleaner, Courier, Cashier
}