namespace SusuLabs.Lab3.Presentation.Menu;

/// <summary>
/// Реализует базовую функциональность меню.
/// </summary>
public abstract class BaseMenu
{
    protected readonly List<string> _menuItems = new ();
    private bool _isOperationInput;
    private int _index;

    protected int MenuIndex
    {
        get => _index;
        private set
        {
            if (value < 0)
            {
                _index = _menuItems.Count - 1;
                return;
            }

            if (value >= _menuItems.Count)
            {
                _index = 0;
                return;
            }

            _index = value;
        }
    }
    
    /// <summary>
    /// Обрабатывает вводимую пользователем клавишу
    /// </summary>
    /// <param name="key">Клавиша, нажатая пользователем</param>
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
                    MenuIndex++; 
                    break;
                
                case ConsoleKey.UpArrow:
                    MenuIndex--;
                    break;

                case ConsoleKey.Enter:
                {
                    _isOperationInput = true;
                } break;
            }
        }
    }
    
    /// <summary>
    /// Занимается отрисовкой меню или пользовательского ввода
    /// </summary>
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

    /// <summary>
    /// Отрисовка и запрос пользовательского ввода
    /// </summary>
    protected abstract void DrawInput();

    /// <summary>
    /// Отрисовка меню
    /// </summary>
    private void DrawMenu()
    {
        for (var i = 0; i < _menuItems.Count; i++)
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