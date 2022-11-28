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
    
    public override bool Equals(object? obj)
    {
        if (obj is not HourlySalaryEmployee employee) return false;

        return employee.Id == Id
               && employee.Name == Name
               && employee.BornDate == BornDate
               && Math.Abs(employee.HourlyRate - HourlyRate) < 0.005
               && Math.Abs(employee.Award - Award) < 0.005
               && employee.JobTitle == JobTitle;
    }

    public override int GetHashCode() => Id.GetHashCode();
}