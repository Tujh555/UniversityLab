using SusuLabs.lab1;
using SusuLabs.lab1.Domain;
using SusuLabs.Lab1.Domain;

namespace SusuLabs.Lab1
{
    public delegate void ShapeCreatedHandler(IShape shape);
    
    internal class ShapeManager
    {
        private readonly List<IShape> _shapes = new List<IShape>();
        public event ShapeCreatedHandler? OnShapeCreated;

        public void CreateRectangle(Point? leftTop = null, double width = 1.0, double height = 1.0)
        {
            var rect = new Rectangle(
                leftTop ?? new Point(0, 0), 
                width, 
                height);
            OnShapeCreated?.Invoke(rect);
            _shapes.Add(rect);
        }

        public void CreateSquare(Point? leftTop = null, double width = 0.0)
        {
            var square = new Square(leftTop ?? new Point(0, 0), width);
            OnShapeCreated?.Invoke(square);
            _shapes.Add(square);
        }

        public void CreateCircle(Point? center = null, double radius = 0.0)
        {
            var circle = new Circle(center ?? new Point(0, 0), radius);
            OnShapeCreated?.Invoke(circle);
            _shapes.Add(circle);
        }
        
        
    }
}
