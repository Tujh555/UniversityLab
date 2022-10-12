namespace SusuLabs.Lab3.Domain.Employees.FixedSalary;

public class SystemAdministrator : FixedSalaryEmployee
{
    public SystemAdministrator(int id, string name, DateTime bornDate, double fixedRate, double award) 
        : base(id, name, bornDate, fixedRate, award) { }

    public override string ToString()
    {
        return $"Системный администратор {Name}\n" +
               $"Дата рождения: {BornDate}\n" +
               $"Заработная плата: {Salary}";
    }
}