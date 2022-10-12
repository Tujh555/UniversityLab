namespace SusuLabs.Lab3.Domain.Employees.HourlySalary;

public abstract class HourlySalaryEmployee : Employee
{
    private readonly double _hourlyRate;
    public override double Salary => _hourlyRate * 20.8 * 8 + Award;
    protected override double Award { get; }

    protected HourlySalaryEmployee(int id, string name, DateTime bornDate, double hourlyRate, double award) : base(id, name, bornDate)
    {
        _hourlyRate = hourlyRate;
        Award = award;
    }
}