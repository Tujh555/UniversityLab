using System.Xml.Serialization;
using SusuLabs.Lab3.Domain.Employees;

namespace SusuLabs.Lab3.Data.Entities;

[
    XmlInclude(typeof(HourlySalaryEmployeeEntity)),
    XmlInclude(typeof(FixedSalaryEmployeeEntity))
]
public class EmployeeEntity
{
    public int Id;
    public string Name;
    public DateTime BornDate;
    public EmployeeJobTitle JobTitle;
    public double Award;
}