using SusuLabs.Lab2.Domain;

namespace SusuLabs.Lab2.Dto;

public class ActionData
{
    public readonly Complex? Complex;
    public readonly Operation? Operation;
    public readonly double? Number;

    public ActionData(Complex? complex = null, Operation? operation = null, double? number = null)
    {
        Complex = complex;
        Operation = operation;
        Number = number;
    }
}