using SusuLabs.lab1.Domain;
using SusuLabs.Lab1.Domain;

namespace SusuLabs.Lab1
{
    internal class ShapeManager
    {
        private readonly List<IShape> _shapes = new();

        public void CreateRectangle(Point? leftTop, double width, double height)
        {
            var rect = new Rectangle(
                leftTop ?? new Point(0, 0), 
                width, 
                height);
            _shapes.Add(rect);
            Console.WriteLine(rect);
        }

        public void CreateSquare(Point? leftTop, double width)
        {
            var square = new Square(leftTop ?? new Point(0, 0), width);
            _shapes.Add(square);
        }

        public void CreateCircle(Point? center, double radius)
        {
            var circle = new Circle(center ?? new Point(0, 0), radius);
            _shapes.Add(circle);
        }

        public void MoveShape(int index, double x, double y)
        {
            if (CheckIndices(index))
            {
                _shapes[index].Move(x, y);
            }
        }

        public void ScaleShape(int index, double coeficient)
        {
            if (CheckIndices(index))
            {
                _shapes[index].Scale(coeficient);
            }
        }

        public void RotateShape(int index, double angle, Point? turningPoint)
        {
            if (CheckIndices(index))
            {
                _shapes[index].Rotate(angle, turningPoint ?? new Point(0, 0));
            }
        }

        public void IsIntersects(int firstIndex, int secondIndex)
        {
            if (!CheckIndices(firstIndex, secondIndex)) return;
            
            var isIntersects = _shapes[firstIndex].Intersects(_shapes[secondIndex]);
            Console.WriteLine(isIntersects ? "Пересекаются" : "Не пересекаются");
        }

        public void PrintAll()
        {
            if (_shapes.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }
            
            foreach (var shape in _shapes)
            {
                Console.WriteLine(shape);
            }
        }

        public void PrintByIndex(int index)
        {
            if (CheckIndices(index))
            {
                Console.WriteLine(_shapes[index]);
            }
        }

        private bool CheckIndices(params int[] indices)
        {
            var isValid = indices.All(x => x < _shapes.Count && x >= 0);
            if (!isValid)
            {
                Console.WriteLine("Фигуры с таким индексом не существует!");
            }

            return isValid;
        }
    }
}
