namespace SusuLabs.Lab3.Domain.Employees;

/// <summary>
/// Представляет базовые свойства сотрудника
/// </summary>
public abstract class Employee
{
    public readonly int Id;
    public readonly string Name;
    public readonly DateTime BornDate;
    public readonly EmployeeJobTitle JobTitle;
    public abstract double Salary { get; }
    public abstract double Award { get; }

    protected Employee(int id, string name, DateTime bornDate, EmployeeJobTitle title)
    {
        Id = id;
        Name = name;
        BornDate = bornDate;
        JobTitle = title;
    }

    public override string ToString()
    {
        return $"{Name}\n" +
               $"Id = {Id}\n" +
               $"Дата рождения: {BornDate}\n" +
               $"Заработная плата: {Salary}";
    }
}