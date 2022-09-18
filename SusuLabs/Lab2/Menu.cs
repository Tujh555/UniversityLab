using System.Diagnostics;

namespace SusuLabs.Lab2;

public delegate void InputRequestHandler();

public class Menu
{
    private readonly string[] _menuItems = {
        "Начать ввод",
        "Выйти"
    };

    private bool _isOperationInput;
    private int _index;
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

    public void PutKey(ConsoleKey key)
    {
        if (_isOperationInput)
        {
            if (key == ConsoleKey.E)
            {
                _isOperationInput = false;
            }
        }
        else
        {
            switch (key)
            {
                case ConsoleKey.DownArrow: 
                    MenuIndex--; 
                    break;
                
                case ConsoleKey.UpArrow:
                    MenuIndex++;
                    break;

                case ConsoleKey.Enter:
                {
                    if (MenuIndex == _menuItems.Length - 1)
                    {
                        Process.GetCurrentProcess().Kill();
                    }

                    _isOperationInput = true;
                } break;
            }
        }
    }

    public void Draw()
    {
        Console.Clear();
        if (_isOperationInput)
        {
            DrawInput();
        }
        else
        {
            DrawMenu();
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
        Console.WriteLine("Формат ввода комплексного числа: <+-> <число> <+-> <число>i или <+-> <число>i <+-> <число>");
        OnInputDraw?.Invoke();
    }
}