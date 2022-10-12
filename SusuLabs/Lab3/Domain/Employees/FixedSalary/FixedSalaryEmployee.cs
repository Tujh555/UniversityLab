namespace SusuLabs.Lab3.Domain.Employees.FixedSalary;

public abstract class FixedSalaryEmployee : Employee
{
    private readonly double _fixedRate;
    public override double Salary => _fixedRate + Award;

    protected override double Award { get; }

    protected FixedSalaryEmployee(int id, string name, DateTime bornDate, double fixedRate, double award) : base(id, name, bornDate)
    {
        _fixedRate = fixedRate;
        Award = award;
    }
}