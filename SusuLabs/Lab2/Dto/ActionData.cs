using SusuLabs.Lab2.Domain;

namespace SusuLabs.Lab2.Dto;

public class ActionData
{
    public readonly Complex? Complex;
    public readonly Operation? Operation;
    public readonly double? Number;

    public ActionData(Complex? complex, Operation? operation, double? number)
    {
        Complex = complex;
        Operation = operation;
        Number = number;
    }

    public ActionData(): this(null, null, null) {}
}