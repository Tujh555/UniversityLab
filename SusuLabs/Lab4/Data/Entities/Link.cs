namespace SusuLabs.Lab4.Data.Entities;

/// <summary>
/// Класс представляющий собой основную информацию о найденной внешней ссылке
/// </summary>
public class Link : ICvsWriteable
{
    public string RootPageUri { get; init; } = "???";
    public string ExternalUri { get; init; } = "???";
    public string Title { get; init; } = "???";
    public int Level { get; init; }
    
    public string ToCvs(string divider) => $"{RootPageUri}{divider}{ExternalUri}{divider}{Title}{divider}{Level}";
}