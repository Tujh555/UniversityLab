namespace SusuLabs.Lab3.Domain.Employees.HourlySalary;

public class Courier : HourlySalaryEmployee
{
    public Courier(int id, string name, DateTime bornDate, double hourlyRate, double award, EmployeeJobTitle title) 
        : base(id, name, bornDate, hourlyRate, award, title) { }

    public override string ToString()
    {
        return "Курьер " + base.ToString();
    }
}