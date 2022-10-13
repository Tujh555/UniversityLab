using SusuLabs.Lab3.Domain.Employees;

namespace SusuLabs.Lab3.Domain;

public class Organization
{
    private List<Employee> _list = new();
    public IReadOnlyCollection<Employee> Employees => _list.AsReadOnly();

    public Employee this[int i] => _list[i];

    public int Size => _list.Count;

    public double AverageMonthlySalary => _list.Average(emp => emp.Salary);

    public static readonly EmployeeBuilder EmployeeBuilder = new();

    public Organization(IEnumerable<Employee> list) => _list.AddRange(list);

    public Organization(params Employee[] employees) => _list.AddRange(employees);

    public void Sort() => _list = _list
        .OrderByDescending(emp => emp.Salary)
        .ThenBy(emp => emp.Name)
        .ToList();

    public void Add(Employee employee) => _list.Add(employee);
}