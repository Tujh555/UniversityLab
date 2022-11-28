namespace SusuLabs.Lab3.Utils;

public static class Utils
{
    /// <summary>
    /// Вспомогательный метод для удобной обработки чего-либо.
    /// </summary>
    /// <param name="it">Объект действия</param>
    /// <param name="block">Действие над объектом</param>
    /// <typeparam name="T"></typeparam>
    /// <returns>Изначальный объект</returns>
    public static T Also<T>(this T it, Action<T> block)
    {
        block(it);
        return it;
    }
}