namespace SusuLabs.Lab3.Domain;

public interface IRepository
{
    void WriteToXml(Organization organization);
    Organization GetFromXml();
}