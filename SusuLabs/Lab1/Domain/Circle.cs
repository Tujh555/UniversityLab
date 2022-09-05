using SusuLabs.lab1;
using SusuLabs.lab1.Domain;

namespace SusuLabs.Lab1.Domain
{
    public class Circle : IShape
    {
        private Point _center;

        public double Radius { get; private set; }

        public Point TopPoint { get; private set; }

        public Point LeftPoint { get; private set; }

        public Point BottomPoint { get; private set; } 

        public Point RightPoint { get; private set; }

        private Point Center
        {
            get => _center;
            set
            {
                TopPoint = new Point(value.X, value.Y + Radius);
                LeftPoint = new Point(value.X - Radius, value.Y);
                BottomPoint = new Point(value.X, value.Y - Radius);
                RightPoint = new Point(value.X + Radius, value.Y);

                _center = value;
            }
        }

        public Circle(double x, double y, double radius)
        {
            Radius = radius;
            Center = new Point(x, y);
        }

        public Circle(Point center, double radius): this(center.X, center.Y, radius) { }
        
        public Circle(double radius) : this(0.0, 0.0, radius) { }

        public void Move(double x, double y) => Center.Move(x, y);

        public void Rotate(double angle, Point turningPoint) => Center.Rotate(angle, turningPoint);

        public void Scale(double coefficient) => Radius *= coefficient;

        public bool Intersects(IShape shape)
        {
            if (shape is Rectangle)
            {
                Rectangle rect = (Rectangle)shape;

                return rect.Intersects(this);
            }

            if (shape is Circle)
            {
                Circle circle = (Circle)shape;

                double distance = MathUtils.GetDistance(Center, circle.Center);

                return distance <= circle.Radius + Radius;
            }

            throw new NotSupportedException();
        }
    }
}
