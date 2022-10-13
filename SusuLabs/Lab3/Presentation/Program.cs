using SusuLabs.Lab3.Data;
using SusuLabs.Lab3.Domain;
using SusuLabs.Lab3.Domain.Employees;

namespace SusuLabs.Lab3.Presentation;

public static class Program
{
    private static IRepository _repository = new FileRepository();
    
    public static void Main(string[] args)
    {
        // var organization = new Organization();
        //
        // organization.Add(
        //     Organization.EmployeeBuilder
        //         .Name("Sasha")
        //         .BornDate(1991, 3, 4)
        //         .FixedRate(124214)
        //         .JobTitle(EmployeeJobTitle.Programmer)
        //         .Award(12)
        //         .Build()
        // );
        //
        // organization.Add(
        //     Organization.EmployeeBuilder
        //         .Name("Grisha")
        //         .BornDate(1995, 1, 4)
        //         .HourlyRate(111)
        //         .JobTitle(EmployeeJobTitle.Courier)
        //         .Award(1212)
        //         .Build()
        // );
        //
        // organization.Add(
        //     Organization.EmployeeBuilder
        //         .Name("Misha")
        //         .BornDate(1984, 11, 2)
        //         .FixedRate(124)
        //         .JobTitle(EmployeeJobTitle.SystemAdministrator)
        //         .Award(0)
        //         .Build()
        // );
        //
        // organization.Add(
        //     Organization.EmployeeBuilder
        //         .Name("Pasha")
        //         .BornDate(2021, 11, 2)
        //         .HourlyRate(1)
        //         .JobTitle(EmployeeJobTitle.Cleaner)
        //         .Build()
        // );
        //
        // _repository.WriteToXml(organization);

        var organization = _repository.GetFromXml();
        organization.Sort();

        foreach (var emp in organization.Employees)
        {
            Console.WriteLine(emp);
            Console.WriteLine();
        }
    }
}