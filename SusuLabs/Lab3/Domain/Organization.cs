using SusuLabs.Lab3.Domain.Employees;

namespace SusuLabs.Lab3.Domain;

public class Organization
{
    private readonly List<Employee> _list = new();

    public Organization(IEnumerable<Employee> list)
    {
        _list.AddRange(list);
    }

    public Organization Sort()
    {
        var list = _list
            .OrderBy(emp => emp.Salary)
            .ThenBy(emp => emp.Name);
        
        return new Organization(list);
    }
}