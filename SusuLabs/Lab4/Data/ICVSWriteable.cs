namespace SusuLabs.Lab4.Data;

/// <summary>
/// Объекты, имплементирующие этот интерфейс могут быть записаны в CVS формате
/// </summary>
public interface ICvsWriteable
{
    public string ToCvs(string divider);
}