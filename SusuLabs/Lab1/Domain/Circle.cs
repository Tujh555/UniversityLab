using SusuLabs.lab1.Domain;

namespace SusuLabs.Lab1.Domain
{
    public class Circle : IShape
    {
        private readonly Point _center;

        private double Radius { get; set; }

        public Point TopPoint => new(_center.X, _center.Y + Radius);

        public Point LeftPoint => new(_center.X - Radius, _center.Y);

        public Point BottomPoint => new(_center.X, _center.Y - Radius);

        public Point RightPoint => new(_center.X + Radius, _center.Y);

        private Circle(double x, double y, double radius)
        {
            Radius = radius;
            _center = new Point(x, y);
        }

        public Circle(Point center, double radius): this(center.X, center.Y, radius) { }

        public void Move(double x, double y) => _center.Move(x, y);

        public void Rotate(double angle, Point turningPoint) => _center.Rotate(angle.ToRadian(), turningPoint);

        public void Scale(double coefficient) => Radius *= coefficient;

        public override string ToString() => $"--> Circle, radius {Radius}\n-> Center: {_center}";

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

                double distance = MathUtils.GetDistance(_center, circle._center);

                return distance <= circle.Radius + Radius;
            }

            throw new NotSupportedException();
        }
    }
}
