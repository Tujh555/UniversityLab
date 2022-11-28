using System.Data;
using System.Xml.Serialization;
using SusuLabs.Lab3.Data.Entities;
using SusuLabs.Lab3.Domain;

namespace SusuLabs.Lab3.Data;

/// <summary>
/// Реализует репозиторий на основе файла
/// </summary>
public class FileRepository : IRepository
{
    private const string FilePath = "Organization.xml";
    private XmlSerializer _serializer = new (typeof(OrganizationEntity));
    
    /// <summary>
    /// Записывает организацию в файл в формате XML
    /// </summary>
    /// <param name="organization">Сохраняемая организация</param>
    public void WriteToXml(Organization organization)
    {
        var organizationEntity = organization.ToEntity();

        using var writer = new StreamWriter(FilePath);
        _serializer.Serialize(writer, organizationEntity);
    }

    /// <summary>
    /// Получает данные организации из файла
    /// </summary>
    /// <returns>Ранее сохраненная организация</returns>
    /// <seealso cref="Organization"/>
    /// <exception cref="DataException">Выбрасывается при неверном формате файла</exception>
    public Organization GetFromXml()
    {
        using var reader = new StreamReader(FilePath);
        var entity = _serializer.Deserialize(reader) as OrganizationEntity ?? throw new DataException("Неверный формат файла");

        return entity.ToOrganization();
    }
}