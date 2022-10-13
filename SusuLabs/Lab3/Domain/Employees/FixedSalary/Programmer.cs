namespace SusuLabs.Lab3.Domain.Employees.FixedSalary;

public class Programmer : FixedSalaryEmployee
{
    public Programmer(int id, string name, DateTime bornDate, double fixedRate, double award, EmployeeJobTitle title) 
        : base(id, name, bornDate, fixedRate, award, title) { }

    public override string ToString()
    {
        return "Программист " + base.ToString();
    }
}