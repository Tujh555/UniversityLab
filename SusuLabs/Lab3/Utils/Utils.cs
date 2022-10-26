namespace SusuLabs.Lab3.Utils;

public static class Utils
{
    public static T Also<T>(this T it, Action<T> block)
    {
        block(it);
        return it;
    }
}