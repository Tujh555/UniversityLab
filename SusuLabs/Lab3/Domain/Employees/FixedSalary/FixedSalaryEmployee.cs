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

    public override bool Equals(object? obj)
    {
        if (obj is not FixedSalaryEmployee employee) return false;

        return employee.Id == Id
               && employee.Name == Name
               && employee.BornDate == BornDate
               && Math.Abs(employee.FixedRate - FixedRate) < 0.005
               && Math.Abs(employee.Award - Award) < 0.005
               && employee.JobTitle == JobTitle;
    }

    public override int GetHashCode() => Id.GetHashCode();
}