using System.Diagnostics;

namespace SusuLabs.Lab3.Presentation.Menu;

public delegate void OnExitItemselected();

public abstract class BaseMenu
{
    private readonly string[] _menuItems;
    private bool _isOperationInput;
    private int _index;

    public event OnExitItemselected? OnExit;
    
    protected BaseMenu(string[] menuItems)
    {
        _menuItems = menuItems;
    }
    
    protected int MenuIndex
    {
        get => _index;
        private set
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
                        OnExit?.Invoke();
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

    protected abstract void DrawInput();

    private void DrawMenu()
    {
        for (var i = 0; i < _menuItems.Length; i++)
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
}