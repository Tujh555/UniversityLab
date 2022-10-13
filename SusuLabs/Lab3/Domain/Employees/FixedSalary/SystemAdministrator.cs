namespace SusuLabs.Lab3.Domain.Employees.FixedSalary;

public class SystemAdministrator : FixedSalaryEmployee
{
    public SystemAdministrator(int id, string name, DateTime bornDate, double fixedRate, double award, EmployeeJobTitle title) 
        : base(id, name, bornDate, fixedRate, award, title) { }

    public override string ToString()
    {
        return "Системный администратор " + base.ToString();
    }
}