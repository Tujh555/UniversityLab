using SusuLabs.Lab2.Domain;
using SusuLabs.Lab2.Dto;

namespace SusuLabs.Lab2;

public class ActionProvider
{
    public string ProcessActionData(ActionData data)
    {
        var complex = data.Complex ?? new Complex(0, 0);
        var operation = data.Operation ?? Operation.Add;
        var number = data.Number ?? 1.0;

        try
        {
            var res = operation switch
            {
                Operation.Add => complex + number,
                Operation.Divide => complex / number,
                Operation.Multiply => complex * number,
                Operation.Subtract => complex - number
            };

            return $"Result: {res}";
        }
        catch (DivideByZeroException e)
        {
            return "На ноль делить нельзя!";
        }
    }
}