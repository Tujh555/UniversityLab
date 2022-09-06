using System.Diagnostics;

namespace SusuLabs.Lab1
{
    internal static class Program
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
        private static readonly ShapeManager Manager = new();
        private static bool _isMainMenuItemSelected;

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
                if (_isMainMenuItemSelected)
                {
                    PrintItem();
                    
                    Console.Write("Чтобы закончить создание нажмите кнопку e , для продолжения - любую другую: ");

                    if (Console.ReadKey().Key == ConsoleKey.E)
                    {
                        _isMainMenuItemSelected = false;
                        Console.Clear();
                        
                    }
                }
                else
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
                            _isMainMenuItemSelected = true;
                            break;
                    }
                }
            }
        }

        private static void PrintItem()
        {
            Console.Clear();
            
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
                5 => "Введите через пробел номер фигуры, угол в градусах и координаты X Y точки поворота.",
                6 => "Введите через пробел номера фигур",
                7 => "Введите номер фигуры.",
                8 => "Полный список фигур: ",
                _ => throw new ArgumentException("Index is unknown")
            };
            
            Console.WriteLine(description);
            var inputString = MenuIndex == 8 ? "" : Console.ReadLine() ?? "";

            switch (MenuIndex)
            {
                case 0:
                {
                    var inputData = Parser.ParseRectangleData(inputString);
                    Manager.CreateRectangle(inputData.point, inputData.width, inputData.height);
                } break;
                
                case 1:
                {
                    var inputData = Parser.ParseSquareData(inputString);
                    Manager.CreateSquare(inputData.point, inputData.length);
                } break;
                
                case 2:
                {
                    var inputData = Parser.ParseCircleData(inputString);
                    Manager.CreateCircle(inputData.point, inputData.radius);
                } break;
                
                case 3:
                {
                    var inputData = Parser.ParseMoveData(inputString);
                    Manager.MoveShape(inputData.index, inputData.x, inputData.y);
                } break;
                
                case 4:
                {
                    var inputData = Parser.ParseScaleData(inputString);
                    Manager.ScaleShape(inputData.index, inputData.coeficient);
                } break;
                
                case 5:
                {
                    var inputData = Parser.ParseRotateData(inputString);
                    Manager.RotateShape(inputData.index, inputData.angle, inputData.point);
                } break;
                
                case 6:
                {
                    var inputData = Parser.ParseIntersectionData(inputString);
                    Manager.IsIntersects(inputData.first, inputData.second);
                } break;
                
                case 7:
                {
                    var inputData = Parser.ParseShapeIndex(inputString);
                    Manager.PrintByIndex(inputData);
                } break;
                
                case 8:
                {
                    Manager.PrintAll();
                } break;
            }
        }
        
        private static void DrawMenu(int row, int col, int index)
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