namespace SusuLabs.Lab3.Domain.Employees.FixedSalary;

public class Secretary : FixedSalaryEmployee
{
    public Secretary(int id, string name, DateTime bornDate, double fixedRate, double award) 
        : base(id, name, bornDate, fixedRate, award) { }

    public override string ToString()
    {
        return $"Секретарь " + base.ToString();
    }
}