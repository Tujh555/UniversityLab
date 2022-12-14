using SusuLabs.Lab3.Data.Entities;
using SusuLabs.Lab3.Domain;
using SusuLabs.Lab3.Domain.Employees;
using SusuLabs.Lab3.Domain.Employees.FixedSalary;
using SusuLabs.Lab3.Domain.Employees.HourlySalary;

namespace SusuLabs.Lab3.Data;

/// <summary>
/// Класс с методами расширениями, предназаченными для приведения
/// объектов слоя бизнесс-логики к объектам модели данных
/// </summary>
public static class DataMapping
{
    private static readonly EmployeeBuilder Builder = new();

    private static readonly EmployeeJobTitle[] FixedSalaryEmployees = {
        EmployeeJobTitle.Programmer,
        EmployeeJobTitle.Secretary,
        EmployeeJobTitle.SystemAdministrator
    };

    private static Employee ToEmployee(this FixedSalaryEmployeeEntity entity)
    {
        return Builder
            .Name(entity.Name)
            .Award(entity.Award)
            .BornDate(entity.BornDate)
            .FixedRate(entity.FixedRate)
            .JobTitle(entity.JobTitle)
            .Id(entity.Id)
            .Build();
    }

    private static Employee ToEmployee(this HourlySalaryEmployeeEntity entity)
    {
        return Builder
            .Name(entity.Name)
            .Award(entity.Award)
            .BornDate(entity.BornDate)
            .HourlyRate(entity.HourlyRate)
            .JobTitle(entity.JobTitle)
            .Id(entity.Id)
            .Build();
    }

    private static EmployeeEntity ToEntity(this FixedSalaryEmployee employee)
    {
        return new FixedSalaryEmployeeEntity
        {
            Id = employee.Id,
            Name = employee.Name,
            BornDate = employee.BornDate,
            JobTitle = employee.JobTitle,
            Award = employee.Award,
            FixedRate = employee.FixedRate
        };
    }

    private static EmployeeEntity ToEntity(this HourlySalaryEmployee employee)
    {
        return new HourlySalaryEmployeeEntity
        {
            Id = employee.Id,
            Name = employee.Name,
            BornDate = employee.BornDate,
            JobTitle = employee.JobTitle,
            Award = employee.Award,
            HourlyRate = employee.HourlyRate
        };
    }

    public static OrganizationEntity ToEntity(this Organization organization)
    {
        return new OrganizationEntity
        {
            Employees = organization.Employees
                .Select(emp =>
                    FixedSalaryEmployees.Contains(emp.JobTitle)
                        ? ((FixedSalaryEmployee)emp).ToEntity()
                        : ((HourlySalaryEmployee)emp).ToEntity()
                ).ToList()
        };
    }

    public static Organization ToOrganization(this OrganizationEntity entity)
    {
        var list = entity.Employees.Select(emp =>
            FixedSalaryEmployees.Contains(emp.JobTitle)
                ? ((FixedSalaryEmployeeEntity)emp).ToEmployee()
                : ((HourlySalaryEmployeeEntity)emp).ToEmployee()
        );

        return new Organization(list);
    }
}