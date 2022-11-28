namespace SusuLabs.Lab3.Presentation.Menu;

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