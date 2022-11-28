using System.Xml.Serialization;
using SusuLabs.Lab3.Domain.Employees;

namespace SusuLabs.Lab3.Data.Entities;

/// <summary>
/// Объект данных сотрудника, предназначенный для хранения в файловой системе в формате XML
/// </summary>
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