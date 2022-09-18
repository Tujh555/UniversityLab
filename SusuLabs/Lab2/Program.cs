namespace SusuLabs.Lab2;

public static class Program
{
    private static readonly Menu _menu = new();
    private static readonly Parser _parser = new();
    private static readonly ActionProvider _provider = new();

    public static void Main(string[] args)
    {
        _parser.ErrorHandler += PrintError;
        _menu.OnInputDraw += RequestAndProceedInput;
        
        while (true)
        {
            _menu.Draw();
            _menu.PutKey(Console.ReadKey().Key);
        }
    }

    private static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private static void RequestAndProceedInput()
    {
        var str = Console.ReadLine() ?? "";
        var data = _parser.ParseInput(str);
        var res = _provider.ProcessActionData(data);
        
        Console.WriteLine(res);
        Console.WriteLine("Для выхода нажмите клавишу e");
    }
}