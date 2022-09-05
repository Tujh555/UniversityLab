using SusuLabs.Lab1.Domain;

namespace SusuLabs.Lab1;

public class Parser
{
    private static double[] GetMetrics(string line) => line.Trim()
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
    
    public static (Point? point, double width, double height) ParseRectangleData(string line)
    {
        var arr = GetMetrics(line);

        return arr.Length switch
        {
            0 => (null, 1, 1),
            1 => (new Point(arr[0], 0), 1, 1),
            2 => (new Point(arr[0], arr[1]), 1, 1),
            3 => (new Point(arr[0], arr[1]), arr[2], 1),
            _ => (new Point(arr[0], arr[1]), arr[2], arr[3])
        };
    }

    public static (Point? point, double length) ParseSquareData(string line)
    {
        var arr = GetMetrics(line);

        return arr.Length switch
        {
            0 => (null, 1),
            1 => (new Point(arr[0], 0), 1),
            2 => (new Point(arr[0], arr[1]), 1),
            _ => (new Point(arr[0], arr[1]), arr[2])
        };
    }

    public static (Point? point, double radius) ParseCircleData(string line) => ParseSquareData(line);
}
