namespace SusuLabs.Lab3.Domain.Employees.HourlySalary;

public class Cleaner : HourlySalaryEmployee
{
    public Cleaner(int id, string name, DateTime bornDate, double hourlyRate, double award) 
        : base(id, name, bornDate, hourlyRate, award) {}

    public override string ToString()
    {
        return "Уборщик " + base.ToString();
    }
}