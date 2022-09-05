using SusuLabs.Lab1.Domain;

namespace SusuLabs.lab1
{
    public interface IShape
    { 
        void Move(double x, double y);

        void Rotate(double angle, Point turningPoint);

        void Scale(double coefficient);

        bool Intersects(IShape shape);
    }
}
