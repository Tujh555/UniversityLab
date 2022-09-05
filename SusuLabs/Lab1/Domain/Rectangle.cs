using SusuLabs.Lab1.Domain;

namespace SusuLabs.lab1.Domain
{
    public class Rectangle : IShape
    {
        protected double Width, Height;
        private readonly Point _leftTopPoint, _rightTopPoint, _leftBottomPoint, _rightBottomPoint;

        private readonly List<Point> _corners = new();

        protected Point LeftTopPoint => _leftTopPoint;

        protected Point RightTopPoint => _rightTopPoint;

        protected Point LeftBottomPoint => _leftBottomPoint;

        protected Point RightBottomPoint => _rightBottomPoint;

        public Rectangle(double x, double y, double width, double height)
        {
            Width = width;
            Height = height;

            _leftTopPoint = new Point(x, y);
            _rightTopPoint = new Point(x + width, y);
            _leftBottomPoint = new Point(x, y - height);
            _rightBottomPoint = new Point(x + width, y - height);

            _corners.Add(_leftTopPoint);
            _corners.Add(_rightTopPoint);
            _corners.Add(_leftBottomPoint);
            _corners.Add(_rightBottomPoint);
        }
        
        public  Rectangle(Point leftTopPoint, double width, double height): this(leftTopPoint.X, leftTopPoint.Y, width, height) { }

        public void Move(double x, double y)
        {
            foreach (var corner in _corners)
            {
                corner.Move(x, y);
            }
        }

        public void Rotate(double angle, Point turningPoint)
        {
            foreach (var corner in _corners)
            {
                corner.Rotate(angle.ToRadian(), turningPoint);
            }
        }

        public void Scale(double coefficient)
        {
            var newHeight = Height * coefficient;
            var newWidth = Width * coefficient;

            var increaseY = (newHeight - Height) / 2;
            var increaseX = (newWidth - Width) / 2;

            Width = newWidth;
            Height = newHeight;

            foreach (var corner in _corners)
            {
                corner.Move(corner.X + increaseX, corner.Y + increaseY);
            }
        }

        public bool Intersects(IShape shape)
        {
            if (shape is Rectangle)
            {
                var s = (Rectangle)shape;

                var angle = MathUtils.GetAngleWithOX(s.LeftBottomPoint, s.RightBottomPoint);
                var turningPoint = MathUtils.GetIntersectionPointWithOX(s.LeftBottomPoint, s.RightBottomPoint);

                s.Rotate(-angle, turningPoint);
                Rotate(-angle, turningPoint);

                bool isIntersectX = _corners.Any(point => point.X >= s.LeftBottomPoint.X && point.X <= s.RightBottomPoint.X);
                bool isIntersectY = _corners.Any(point => point.Y >= s.LeftBottomPoint.Y && point.Y <= s.LeftTopPoint.Y);

                s.Rotate(angle, turningPoint);
                Rotate(angle, turningPoint);

                return isIntersectX && isIntersectY;
            }

            if (shape is Circle)
            {
                var s = (Circle)shape;

                var angle  = MathUtils.GetAngleWithOX(LeftBottomPoint, RightBottomPoint);
                var turningPoint = MathUtils.GetIntersectionPointWithOX(LeftBottomPoint, RightBottomPoint);

                s.Rotate(-angle, turningPoint);
                Rotate(-angle, turningPoint);

                bool isIntersectX = s.LeftPoint.X >= LeftBottomPoint.X && s.LeftPoint.X <= RightBottomPoint.X ||
                    s.RightPoint.X >= LeftBottomPoint.X && s.RightPoint.X <= RightBottomPoint.X;
                bool isIntersectY = s.BottomPoint.Y >= LeftBottomPoint.Y && s.BottomPoint.Y <= LeftTopPoint.Y ||
                    s.TopPoint.Y <= LeftBottomPoint.Y && s.TopPoint.Y <= LeftTopPoint.Y;

                s.Rotate(angle, turningPoint);
                Rotate(angle, turningPoint);

                return isIntersectX && isIntersectY;
            }

            throw new NotSupportedException();
        }

        public override string ToString() => $"--> Rectangle, height = {Height}, width = {Width}\n" +
            $"-> Coordinates: {LeftTopPoint}, {RightTopPoint}, {LeftBottomPoint}, {RightBottomPoint}";
    }
}
