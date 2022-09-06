using SusuLabs.lab1.Domain;

namespace SusuLabs.Lab1.Domain
{
    public class Square : Rectangle
    {
        private Square(double x, double y, double width) : base(x, y, width, width) { }

        public Square(double width) : this(0.0, 0.0, width) { }
        
        public Square(Point leftTop, double width): this(leftTop.X, leftTop.Y, width) { }

        public override string ToString() => $"--> Square, length = {Width}\n" +
            $"-> Coordinates: {LeftTopPoint}, {RightTopPoint}, {LeftBottomPoint}, {RightBottomPoint}";
    }
}
