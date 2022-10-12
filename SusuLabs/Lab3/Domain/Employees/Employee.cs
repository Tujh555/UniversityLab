namespace SusuLabs.Lab3.Domain.Employees;

public abstract class Employee
{
    public readonly int Id;
    public readonly string Name;
    public readonly DateTime BornDate;
    public abstract double Salary { get; }
    protected abstract double Award { get; }

    protected Employee(int id, string name, DateTime bornDate)
    {
        Id = id;
        Name = name;
        BornDate = bornDate;
    }

    public override string ToString()
    {
        return $"{Name}\n" +
               $"Id = {Id}\n" +
               $"Дата рождения: {BornDate}\n" +
               $"Заработная плата: {Salary}";
    }
}