using System.Text;

namespace SusuLabs.Lab4.Data;

/// <summary>
/// Класс, осуществляющий запись данных в формате CVS
/// </summary>
public static class CvsWriter
{
    public static void Write(IEnumerable<ICvsWriteable> items, string filePath, string divider = ";")
    {
        var res = items.Aggregate("", (acc, next) => acc + next.ToCvs(divider) + '\n');
        File.WriteAllText(filePath, res, Encoding.UTF8);
    }
}