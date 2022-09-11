using System.Text;
using SusuLabs.Lab2.Domain;

namespace SusuLabs.Lab2;

public delegate void ComplexParsingErrorHandler(string message);
public class Parser
{
    private readonly HashSet<char> _validSymbols = new(new[] { 'i', ' ', ',', '+', '-', '.' });
    public event ComplexParsingErrorHandler? ErrorHandler;

    public Complex? TryGetComplex(string? num)
    {
        if (num == null || !IsStringValid(num))
        {
            ErrorHandler?.Invoke("Комлексное число введено в неподдерживаемой форме.\n" +
                            "Вводимое число должно соответствовать правилу: \n" +
                            "<арифметический_знак> <число> <арифметический_знак> <число>i");
            return null;
        }

        var n = FormatString(num);
        double real, imaginary;
        
        try
        {
            var data = GetDividedString(n);
            real = double.Parse(data.real);
            imaginary = double.Parse(data.imaginary);
        }
        catch (IndexOutOfRangeException e)
        {
            ErrorHandler?.Invoke("Введено недопустимое количество арифметических знаков.");
            return null;
        }

        return new Complex(real, imaginary);
    }

    private (string real, string imaginary) GetDividedString(string str)
    {
        var data = new string[2];
        var builder = new StringBuilder();
        var length = 0;

        foreach (var c in str)
        {
            if (c == '-' || c == '+')
            {
                var s = builder.ToString();
                if (!string.IsNullOrEmpty(s))
                {
                    data[length++] = s;
                }
                
                builder.Clear();
            }

            builder.Append(c);
        }
        
        data[length++] = builder.ToString();
        return data[0].Contains('i')
            ? (data[1], data[0].Replace("i", "")) 
            : (data[0], data[1].Replace("i", ""));
    }

    private string FormatString(string str) => str
        .Replace(" ", "")
        .Replace(".", ",")
        .ToLower();

    private bool IsStringValid(string str)
    {
        var imaginaryCount = 0;

        foreach (var c in str.ToLower())
        {
            if (!(_validSymbols.Contains(c) || char.IsDigit(c)))
            {
                return false;
            }

            if (c == 'i')
            {
                imaginaryCount++;
            }
        }

        return str.Length > 0 && imaginaryCount == 1;
    }
}