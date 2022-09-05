using SusuLabs.Lab1.Domain;

namespace SusuLabs.Lab1;

public class Parser
{
    public (Point? point, double width, double height) ParseRectangleData(string line)
    {
        var arr = line.Trim()
            .Replace('.', ',')
            .Split(" ")
            .Select(s =>
            {
                try
                {
                    return double.Parse(s);
                }
                catch (Exception e)
                {
                    return default;
                }
            })
            .ToArray();

        switch (arr.Length)
        {
            case 0:
            {
                return (new Point(0, 0), 1, 1);
            }

            case 1:
            {
                return (new Point(arr[0], 0), 1, 1);
            }

            case 2:
            {
                return (new Point(arr[0], arr[1]), 1, 1);
            } 

            case 3:
            {
                return (new Point(arr[0], arr[1]), arr[2], 1);
            }

            default:
            {
                return (new Point(arr[0], arr[1]), arr[2], arr[3]);
            }
        }
    }
}