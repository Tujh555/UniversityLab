namespace SusuLabs.Lab3.Domain.Employees.FixedSalary;

public abstract class FixedSalaryEmployee : Employee
{
    public readonly double FixedRate;
    public override double Salary => FixedRate + Award;

    public override double Award { get; }

    protected FixedSalaryEmployee(int id, string name, DateTime bornDate, double fixedRate, double award, EmployeeJobTitle title) 
        : base(id, name, bornDate, title)
    {
        FixedRate = fixedRate;
        Award = award;
    }
}