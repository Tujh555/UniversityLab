namespace SusuLabs.Lab1
{
    internal class Program
    {
        private static readonly string[] _mainMenuItems =
        {
            "Создать",
            "Повернуть",
            "Пересечение",
            "Вывести фигуру",
            "Вывести все фигуры",
            "Выход"
        };

        private static int _index; 

        private static int MenuIndex
        {
            get => _index;
            set
            {
                if (value < 0)
                {
                    _index = _mainMenuItems.Length - 1;
                    return;
                }

                if (value >= _mainMenuItems.Length)
                {
                    _index = 0;
                    return;
                }

                _index = value;
            }
        }
        
        public static void Main(string[] args)
        {
            // Console.WriteLine("Меню");
            // Console.WriteLine();

            int row = Console.CursorTop, col = Console.CursorLeft;

            while (true)
            {
                DrawMenu(row, col, _index);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow: 
                        MenuIndex++;
                        break;
                    
                    case ConsoleKey.UpArrow:
                        MenuIndex--;
                        break;

                    case ConsoleKey.Enter:
                    {
                        PrintItem(MenuIndex);
                    } break;
                }
            }
        }

        private static void PrintItem(int index)
        {
            if (index == _mainMenuItems.Length - 1)
            {
                Console.WriteLine("Выход");
            }
            else
            {
                Console.WriteLine($"Выбран пункт {_mainMenuItems[index]}");
            }
        }

        public static void DrawMenu(int row, int col, int index)
        {
            
            Console.SetCursorPosition(row, col);

            for (int i = 0; i < _mainMenuItems.Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(_mainMenuItems[i]);
                Console.ResetColor();
            }
            
            Console.WriteLine();
        }
    }
}