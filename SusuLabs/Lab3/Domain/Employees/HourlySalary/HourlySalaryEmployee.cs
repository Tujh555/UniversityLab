namespace SusuLabs.Lab3.Domain.Employees.HourlySalary;

public abstract class HourlySalaryEmployee : Employee
{
    public readonly double HourlyRate;
    public override double Salary => HourlyRate * 20.8 * 8 + Award;
    public override double Award { get; }

    protected HourlySalaryEmployee(int id, string name, DateTime bornDate, double hourlyRate, double award, EmployeeJobTitle title) : base(id, name, bornDate, title)
    {
        HourlyRate = hourlyRate;
        Award = award;
    }
}