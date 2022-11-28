using System.Diagnostics;
using SusuLabs.Lab3.Data;
using SusuLabs.Lab3.Domain;
using SusuLabs.Lab3.Presentation.Menu;
using SusuLabs.Lab3.Presentation.MenuAnnotationBuilder;
using SusuLabs.Lab3.Utils;

namespace SusuLabs.Lab3.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var program = new MainProgram();
        program.Start();
    }
}

internal class MainProgram
{
    private static Organization _organization = new();
    private static readonly IRepository Repository = new FileRepository();
    private static readonly EmployeeParser Parser = new();
    private readonly BaseMenu _menu;

    public MainProgram()
    {
        _menu = MenuBinder.BindMenu(this);
        Parser.CreationResult.Observe(emp => _organization.Add(emp));
    }

    public void Start()
    {
        while (true)
        {
            _menu.Draw();
            _menu.PutKey(Console.ReadKey().Key);
        }
    }

    [MenuItem("Сохранить организацию в файл")]
    private static void SaveOrganizationToFile()
    {
        Repository.WriteToXml(_organization);
    }

    [MenuItem("Загрузить организацию из файла")]
    private static void GetOrganizationFromFile()
    {
        try
        {
            _organization = Repository.GetFromXml();
        }
        catch (Exception e)
        {
            Console.WriteLine("Произошла ошибка чтения данных");
        }
    }

    [MenuItem("Удалить сотрудника")]
    private static void DeleteEmployee()
    {
        Console.WriteLine("Введите номер сотрудника которого хотите удалить");
        var num = int.Parse(Console.ReadLine()!);
        _organization.Delete(num);
    }

    [MenuItem("Добавить сотрудника")]
    private static void AddEmployee()
    {
        Parser.Parse();
    }

    [MenuItem("Вывести последние 3 идентификатора сотрудников")]
    private static void PrintLastThreeIdEmployees()
    {
        if (_organization.Size == 0)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        for (var i = Math.Min(2, _organization.Size - 1); i >= 0; i--)
        {
            Console.WriteLine(_organization[i].Id);
        }
    }

    [MenuItem("Вывести первые 5 имён сотрудников")]
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

    [MenuItem("Вывести полный список сотрудников")]
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

    [MenuItem("Сортировать сотрудников")]
    private static void SortEmployees()
    {
        _organization.Sort();
    }

    [MenuItem("Выход")]
    private static void Exit()
    {
        Process.GetCurrentProcess().Kill();
    }
}