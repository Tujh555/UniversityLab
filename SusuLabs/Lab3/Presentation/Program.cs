using System.Diagnostics;
using System.Security.AccessControl;
using SusuLabs.Lab3.Data;
using SusuLabs.Lab3.Domain;
using SusuLabs.Lab3.Domain.Employees;
using SusuLabs.Lab3.Presentation.Menu;
using SusuLabs.Lab3.Utils;

namespace SusuLabs.Lab3.Presentation;

public static class Program
{
    private static string[] _mainMenuItems =
    {
        "Сортировать сотрудников",
        "Вывести полный список сотрудников",
        "Вывести первые 5 имён сотрудников",
        "Вывести последние 3 идентификатора сотрудников",
        "Добавить сотрудника",
        "Удалить сотрудника",
        "Загрузить организацию из файла",
        "Сохранить организацию в файл",
        "Выход"
    };

    private static Dictionary<int, OnMenuItemSelected> _maibMenuCallbacks = new()
    {
        { 0, SortEmployees },
        { 1, PrintAllEmployees },
        { 2, PrintFirstFiveEmployees },
        { 3, PrintLastThreeIdEmployees },
        { 4, AddEmployee },
        { 5, DeleteEmployee },
        { 6, GetOrganizationFromFile },
        { 7, SaveOrganizationToFile }
    };

    private static string[] _employeeCreationMenuItems =
    {
        "Начать ввод",
        "Отмена"
    };

    private static Organization _organization = new();
    private static readonly IRepository _repository = new FileRepository();
    private static MainMenu _mainMenu = new(_mainMenuItems, _maibMenuCallbacks);
    private static EmployeeCreationMenu _creationMenu = new(_employeeCreationMenuItems);
    private static BaseMenu _currentMenu = _mainMenu;

    public static void Main(string[] args)
    {
        _mainMenu.OnExit += Process.GetCurrentProcess().Kill;
        _creationMenu.OnExit += () => { _currentMenu = _mainMenu; };
        _creationMenu.EmployeeLiveData.Observe(emp => _organization.Add(emp));

        while (true)
        {
            _currentMenu.Draw();
            _currentMenu.PutKey(Console.ReadKey().Key);
        }
    }

    private static void SaveOrganizationToFile()
    {
        _repository.WriteToXml(_organization);
    }

    private static void GetOrganizationFromFile()
    {
        _organization = _repository.GetFromXml();
    }

    private static void DeleteEmployee()
    {
        Console.WriteLine("Введите номер сотрудника которого хотите удалить");
        var num = int.Parse(Console.ReadLine()!);
        _organization.Delete(num);
    }

    private static void AddEmployee()
    {
        _currentMenu.PutKey(ConsoleKey.E);
        _currentMenu = _creationMenu;
    }

    private static void PrintLastThreeIdEmployees()
    { 
        if (_organization.Size == 0)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        for (var i = Math.Min(2, _organization.Size); i >= 0; i--)
        {
            Console.WriteLine(_organization[i].Id);
        }
    }

    private static void PrintFirstFiveEmployees()
    {
        if (_organization.Size == 0)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        for (var i = 0; i <= Math.Min(5, _organization.Size - 1); i++)
        {
            Console.WriteLine(_organization[i].Name);
        }
    }

    private static void PrintAllEmployees()
    {
        if (_organization.Size == 0)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        Console.WriteLine($"Среднемесячная зарплата: {_organization.AverageMonthlySalary}");
        Console.WriteLine();
        
        for (var i = 0; i < _organization.Size; i++)
        {
            Console.WriteLine(_organization[i]);
            Console.WriteLine("<====>");
        }
    }

    private static void SortEmployees()
    {
        _organization.Sort();
    }
}