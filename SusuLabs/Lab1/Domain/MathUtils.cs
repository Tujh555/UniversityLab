namespace SusuLabs.Lab1.Domain
{
    internal static class MathUtils
    {
        public static double ToRadian(this double angle) => angle * (Math.PI / 180);
        
        public static double GetDistance(Point p1, Point p2)
        {
            var diffX = p1.X - p2.X;
            var diffY = p1.Y - p2.Y;

            return Math.Sqrt(diffX * diffX + diffY * diffY);
        }

        public static double GetAngleWithOx(Point p1, Point p2)
        {
            Point vector = new Point(p1.X - p2.X, p1.Y - p2.Y);

            double denominator = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);

            return Math.Acos(vector.X / denominator);
        }

        public static Point GetIntersectionPointWithOx(Point p1, Point p2)
        {
            var coefY2 = p2.Y * (p2.X - p1.X);
            var coefX2 = p2.X * (p2.Y - p1.Y);

            var y0 = (coefY2 - coefX2) / (p2.X - p1.X);
            var x0 = (coefX2 - coefY2) / (p2.Y - p1.Y);

            return new Point(x0, y0);
        }
    }
}
