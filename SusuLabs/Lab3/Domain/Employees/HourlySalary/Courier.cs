namespace SusuLabs.Lab3.Domain.Employees.HourlySalary;

public class Courier : HourlySalaryEmployee
{
    public Courier(int id, string name, DateTime bornDate, double hourlyRate, double award) 
        : base(id, name, bornDate, hourlyRate, award) { }

    public override string ToString()
    {
        return $"Круьер {Name}\n" +
               $"Дата рождения: {BornDate}\n" +
               $"Заработная плата: {Salary}";
    }
}