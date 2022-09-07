using SusuLabs.Lab1.Domain;

namespace SusuLabs.Lab1;

public static class Parser
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

    public static (int index, double x, double y) ParseMoveData(string line)
    {
        var arr = GetMetrics(line);

        return arr.Length switch
        {
            0 => (default, 1, 1),
            1 => ((int)arr[0], 1, 1),
            2 => ((int)arr[0], arr[1], 1),
            _ => ((int)arr[0], arr[1], arr[2])
        };
    }

    public static (int index, double angle, Point? point) ParseRotateData(string line)
    {
        var arr = GetMetrics(line);

        return arr.Length switch
        {
            0 => (default, 1, null),
            1 => ((int)arr[0], 1, null),
            2 => ((int)arr[0], arr[1], new Point(0, 0)),
            3 => ((int)arr[0], arr[1], new Point(arr[2], 0)),
            _ => ((int)arr[0], arr[1], new Point(arr[2], arr[3]))
        };
    }

    public static (int index, double coeficient) ParseScaleData(string line)
    {
        var arr = GetMetrics(line);

        return arr.Length switch
        {
            0 => (default, 1),
            1 => ((int)arr[0], 1),
            _ => ((int)arr[0], arr[1])
        };
    }

    public static (int first, int second) ParseIntersectionData(string line)
    {
        var arr = GetMetrics(line);

        return arr.Length switch
        {
            0 => (default, default),
            1 => ((int)arr[0], default),
            _ => ((int)arr[0], (int)arr[1])
        };
    }

    public static int ParseShapeIndex(string line)
    {
        var arr = GetMetrics(line);

        return arr.Length switch
        {
            0 => default,
            _ => (int)arr[0]
        };
    }
}
