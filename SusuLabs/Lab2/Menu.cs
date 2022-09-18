using System.Diagnostics;

namespace SusuLabs.Lab2;

public delegate void InputRequestHandler();

public class Menu
{
    private readonly string[] _menuItems = {
        "Начать ввод",
        "Выйти"
    };

    private bool _isOperationInput = false;
    private int _index = 0;
    public event InputRequestHandler? OnInputDraw;
    
    private int MenuIndex
    {
        get => _index;
        set
        {
            if (value < 0)
            {
                _index = _menuItems.Length - 1;
                return;
            }

            if (value >= _menuItems.Length)
            {
                _index = 0;
                return;
            }

            _index = value;
        }
    }

    public void Draw(ConsoleKey key)
    {
        if (_isOperationInput)
        {
            DrawInput();

            switch (key)
            {
                case ConsoleKey.E:
                    Process.GetCurrentProcess().Kill();
                    break;
            }
        }
        else
        {
            DrawMenu();

            switch (key)
            {
                case ConsoleKey.DownArrow: 
                    MenuIndex--; 
                    break;
                
                case ConsoleKey.UpArrow:
                    MenuIndex++;
                    break;
                
                case ConsoleKey.Enter:
                    _isOperationInput = true;
                    break;
            }
        }
    }

    private void DrawMenu()
    {
        for (int i = 0; i < _menuItems.Length; i++)
        {
            if (i == MenuIndex)
            {
                Console.BackgroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine(_menuItems[i]);
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    private void DrawInput()
    {
        Console.WriteLine("Введите операнды и операцию.");
        Console.WriteLine("Формат ввода: (<комплексное число>) <знак арифметической операции> <обычное число>");
        Console.WriteLine("Или: <обычное число> <знак арифметической операции> (<комплексное число>)");
        OnInputDraw?.Invoke();
    }
}