using System.Text;
using SusuLabs.Lab2.Domain;
using SusuLabs.Lab2.Dto;

namespace SusuLabs.Lab2;

public static class Program
{
    public static void Main(string[] args)
    {
        var menu = new Menu();
        menu.OnInputDraw += GetString;

        var parser = new Parser();
        parser.ErrorHandler += PrintError;
        var s = "(7 + 1224.24i) / 21,0";

        var data = parser.ParseInput(s);
        
        Console.WriteLine($"{data.Complex}\n{data.Operation?.ToString() ?? "null"}\n{data.Number?.ToString() ?? "null"}");

    }

    private static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private static void GetString()
    {
        Console.ReadLine();
    }
}