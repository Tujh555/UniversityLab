using System.Text;
using SusuLabs.Lab2.Domain;
using SusuLabs.Lab2.Dto;

namespace SusuLabs.Lab2;

public delegate void ComplexParsingErrorHandler(string message);
public class Parser
{
    private readonly HashSet<char> _validComplexSymbols = new(new[] { 'i', ' ', ',', '+', '-', '.' });
    private readonly HashSet<char> _arithmeticSigns = new(new[] { '+', '-', '*', '/' });
    public event ComplexParsingErrorHandler? ErrorHandler;

    public ActionData ParseInput(string line)
    {
        if (line[0] != '(')
        {
            ErrorHandler?.Invoke("Операция введена в неправильном формате.");
            return new ActionData();
        }
        
        string[] s = line
            .Split(")")
            .Select(str => FormatString(str).Replace( "(", ""))
            .ToArray();

        try
        {
            var complexString = s.First(str => str.Contains('i'));
            var doubleString = s.First(str => str != complexString);
            
            return new ActionData(
                GetComplex(complexString), 
                GetOperation(doubleString), 
                GetNumber(doubleString));
        }
        catch (Exception e)
        {
            ErrorHandler?.Invoke("Операция введена в неправильном формате.");
            return new ActionData();
        }
    }

    private Operation? GetOperation(string line)
    {
        char operation = line.First(c => !char.IsDigit(c));

        if (_arithmeticSigns.Contains(operation)) return operation switch
        {
            '+' => Operation.Add,
            '-' => Operation.Subtract,
            '*' => Operation.Multiply,
            '/' => Operation.Divide
        };
        
        ErrorHandler?.Invoke($"Неизвестная арифметическая операция {operation}");
        return null;

    }

    private double? GetNumber(string line)
    {
        var num = line.Where(char.IsDigit).Aggregate("", (x, y) => x + y);

        try
        {
            return double.Parse(num);
        }
        catch (Exception e)
        {
            ErrorHandler?.Invoke($"Число {num} введено в некорректной форме.");
            return null;
        }
    }
    
    private Complex? GetComplex(string num)
    {
        if (!IsStringValid(num))
        {
            ErrorHandler?.Invoke($"Комлексное число {num} введено в неподдерживаемой форме.\n" +
                            "Вводимое число должно соответствовать правилу: \n" +
                            "<+-> <число> <+-> <число>i");
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
        catch (FormatException e)
        {
            ErrorHandler?.Invoke($"Одна из частей числа {num} введена в некорректной форме");
            return null;
        }

        return new Complex(real, imaginary);
    }

    private (string real, string imaginary) GetDividedString(string str)
    {
        var data = new[] { "0", "0i" };
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
            if (!(_validComplexSymbols.Contains(c) || char.IsDigit(c)))
            {
                return false;
            }

            if (c == 'i')
            {
                imaginaryCount++;
            }
        }

        return str.Length > 0 && imaginaryCount <= 1;
    }
}