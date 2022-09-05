using System.Diagnostics;

namespace SusuLabs.Lab1
{
    internal class Program
    {
        private static readonly string[] _mainMenuItems =
        {
            "Создать прямоугольник",
            "Создать квадрат",
            "Создать круг",
            "Переместить",
            "Изменить размер",
            "Повернуть",
            "Пересечение",
            "Вывести фигуру",
            "Вывести все фигуры",
            "Выход"
        };

        private static int _index;
        private static readonly ShapeManager _manager = new();

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
                        PrintItem();
                    }
                        break;
                }
            }
        }

        private static void PrintItem()
        {
            if (MenuIndex == _mainMenuItems.Length - 1)
            {
                Process.GetCurrentProcess().Kill();
            }

            Console.WriteLine(_mainMenuItems[MenuIndex]);

            string description = MenuIndex switch
            {
                0 => "Введите координаты X и Y верхнего левого угла через пробел.\n Затем введите через пробел ширину и высоту.",
                1 => "Введите координаты X и Y верхнего левого угла через пробел.\n Затем введите длину стороны.",
                2 => "Введите координаты X и Y центра через пробел.\n Затем введите радиус",
                3 => "Введите через пробел номер фигуры и координаты X Y вектора, на который нужно переместить фигуру.",
                4 => "Введите через пробел номер фигуры и коэфициент изменения размера фигуры.",
                5 => "Введите через пробел номер фигуры и координаты X Y точки поворота.",
                6 => "Введите через пробел номера фигур",
                7 => "Введите номер фигуры.",
                8 => "Полный список фигур: ",
                _ => throw new ArgumentException("Index is unknown")
            };
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