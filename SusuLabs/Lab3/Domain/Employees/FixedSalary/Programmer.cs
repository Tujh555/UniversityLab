namespace SusuLabs.Lab3.Domain.Employees.FixedSalary;

public class Programmer : FixedSalaryEmployee
{
    public Programmer(int id, string name, DateTime bornDate, double fixedRate, double award) 
        : base(id, name, bornDate, fixedRate, award) { }

    public override string ToString()
    {
        return "Программист " + base.ToString();
    }
}