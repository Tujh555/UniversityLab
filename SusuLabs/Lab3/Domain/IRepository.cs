namespace SusuLabs.Lab3.Domain;

/// <summary>
/// Объявляет методы репозитория
/// </summary>
public interface IRepository
{
    void WriteToXml(Organization organization);
    Organization GetFromXml();
}