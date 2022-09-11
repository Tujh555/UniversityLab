namespace SusuLabs.Lab2.Domain;

public class Complex
{
    private readonly double _real, _imaginary;

    public static implicit operator double(Complex complex)
    {
        return complex._real;
    }
    
    public static Complex operator +(Complex num1, Complex num2)
    {
        return new Complex(num1._real + num2._real, num1._imaginary + num2._imaginary);
    }

    public static Complex operator -(Complex num1, Complex num2)
    {
        return new Complex(num1._real - num2._real, num1._imaginary - num2._imaginary);
    }
    
    public static Complex operator *(Complex num1, Complex num2)
    {
        return new Complex(
            num1._real * num2._real - num1._imaginary * num2._imaginary,
            num1._real * num2._imaginary + num2._real * num1._imaginary);
    }

    public static Complex operator /(Complex num1, Complex num2)
    {
        var divider = num2._real * num2._real + num2._imaginary * num2._imaginary;

        if (divider == 0)
        {
            throw new DivideByZeroException("Divider must not equal zero.");
        }

        return new Complex(
            (num1._real * num2._real + num1._imaginary * num2._imaginary) / divider,
            (num2._real * num1._imaginary - num1._real * num2._imaginary) / divider);
    }
    
    public static Complex operator +(Complex complex, double num)
    {
        return new Complex(complex._real + num, complex._imaginary);
    }

    public static Complex operator -(Complex complex, double num)
    {
        return new Complex(complex._real - num, complex._imaginary);
    }

    public static Complex operator *(Complex complex, double num)
    {
        return new Complex(complex._imaginary * num, complex._real * num);
    }
    
    public static Complex operator /(Complex complex, double num)
    {
        if (num == 0)
        {
            throw new DivideByZeroException("Divider must not equal zero.");
        }
        
        return new Complex(complex._imaginary / num, complex._real / num);
    }

    public Complex(double real, double imaginary)
    {
        _real = real;
        _imaginary = imaginary;
    }

    public bool CanBeReal() => _imaginary == 0.0;

    public override string ToString() => $"{_real} + {_imaginary}i";
}