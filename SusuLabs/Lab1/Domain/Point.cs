namespace SusuLabs.Lab1.Domain
{
    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point(double x, double y)
        {
            X = x; 
            Y = y; 
        }

        public void Move(double x, double y)
        {
            X += x;
            Y += y;
        }

        public void Rotate(double angle, Point turningPoint)
        {
            X -= turningPoint.X;
            Y -= turningPoint.Y;

            double x1 = X * Math.Cos(angle) - Y * Math.Sin(angle);
            double y1 = X * Math.Sin(angle) + Y * Math.Cos(angle);

            X = x1 + turningPoint.X;
            Y = y1 + turningPoint.Y;
        }

        public override string ToString() => $"({X:F1}, {Y:F1})";
    }
}
