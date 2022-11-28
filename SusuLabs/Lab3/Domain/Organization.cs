using SusuLabs.Lab3.Domain.Employees;

namespace SusuLabs.Lab3.Domain;

/// <summary>
/// Класс представляющий органзацию
/// </summary>
public class Organization
{
    private List<Employee> _list = new();
    public IReadOnlyCollection<Employee> Employees => _list.AsReadOnly();

    public Employee this[int i] => _list[i];

    public int Size => _list.Count;

    public double AverageMonthlySalary => _list.Average(emp => emp.Salary);

    public Organization(IEnumerable<Employee> list) => _list.AddRange(list);

    public Organization(params Employee[] employees) => _list.AddRange(employees);

    public void Sort() => _list = _list
        .OrderByDescending(emp => emp.Salary)
        .ThenBy(emp => emp.Name)
        .ToList();

    public void Add(Employee employee) => _list.Add(employee);

    /// <summary>
    /// Удаляет пользователя из коллекции, вызывая при этом переданный callback
    /// </summary>
    /// <param name="index">Индекс сотрудника</param>
    /// <param name="onDelete">Действие при удалении сотрудника</param>
    public void Delete(int index, Action<Employee>? onDelete = null)
    {
        try
        {
            onDelete?.Invoke(_list[index]);
            _list.RemoveAt(index);
        }
        catch (Exception _)
        {
            // ignored
        }
    }
}