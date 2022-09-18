namespace SusuLabs.Lab2.Domain;

public class Complex
{
    private readonly double _real, _imaginary;

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
        return new Complex(complex._real * num, complex._imaginary * num);
    }
    
    public static Complex operator /(Complex complex, double num)
    {
        if (num == 0)
        {
            throw new DivideByZeroException("Divider must not equal zero.");
        }
        
        return new Complex(complex._real / num, complex._imaginary / num);
    }

    public static Complex operator -(Complex complex)
    {
        return new Complex(-complex._real, -complex._imaginary);
    }
    
    public Complex(double real, double imaginary)
    {
        _real = real;
        _imaginary = imaginary;
    }

    public override string ToString()
    {
        var sign = _imaginary < 0 ? "-" : "+";
        var formattedImaginary = _imaginary < 0 ? -_imaginary : _imaginary;
        
        return $"{_real} {sign} {formattedImaginary}i";
    }
}