using System.Data;
using System.Xml.Serialization;
using SusuLabs.Lab3.Data.Entities;
using SusuLabs.Lab3.Domain;

namespace SusuLabs.Lab3.Data;

public class FileRepository : IRepository
{
    private const string _filePath = "C:/XmlFolder/Organization.xml";
    private XmlSerializer serializer = new (typeof(OrganizationEntity));
    
    public void WriteToXml(Organization organization)
    {
        var organizationEntity = organization.ToEntity();

        using var writer = new StreamWriter(_filePath);
        serializer.Serialize(writer, organizationEntity);
    }

    public Organization GetFromXml()
    {
        using var reader = new StreamReader(_filePath);
        var entity = serializer.Deserialize(reader) as OrganizationEntity ?? throw new DataException("Неверный формат файла");

        return entity.ToOrganization();
    }
}