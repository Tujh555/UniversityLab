using SusuLabs.Lab3.Domain.Employees;
using SusuLabs.Lab3.Domain.Employees.HourlySalary;

namespace SusuLabs.Lab3;

public class Program
{
    public static void Main(string[] args)
    {
        var courier = new Courier(
            12,
            "VAsya",
            new DateTime(1992, 2, 2),
            123,
            12.33);
        
        Console.WriteLine(courier);
    }
}