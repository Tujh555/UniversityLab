using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using SusuLabs.Lab4.Data.Entities;

namespace SusuLabs.Lab4.Data;

/// <summary>
/// Класс осуществляет сканирование web-страниц и поиск внешних ссылок
/// </summary>
public class LinkLoader : IDisposable
{
    [Obsolete("Obsolete")] private readonly WebClient _client = new();
    private readonly HashSet<Uri> _procLinks = new();
    private int _currentLevel;
    
    public delegate void OnLinkFound(Link[] links);

    public event OnLinkFound? ExternalLinkFoundEvent;

    public event Action? LoadingEndEvent;

    [Obsolete("Obsolete")]
    public LinkLoader()
    {
        _client.Headers.Add("User-Agent",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.5112.102 Safari/537.36 OPR/90.0.4480.84");
        _client.Headers.Add("Accept",
            "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
        _client.Headers.Add("Accept-Language", "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");
        _client.Encoding = Encoding.UTF8;
    }

    /// <summary>
    /// Метод загружает страницу по предоставленному uri и парсит её.
    /// Если он находит внутренние ссылки, то проходит рекурсивно и по ним.
    /// </summary>
    /// <param name="page">Uri страницы</param>
    /// <param name="count">Количество страниц, которые нужно распарсить</param>
    private void Load(Uri page, int count)
    {
        if (count <= 0) return;
        _currentLevel++;

        if (_procLinks.Contains(page)) return;

        _procLinks.Add(page);
        
        string pageHtml;

        try
        {
            pageHtml = _client.DownloadString(page);
        }
        catch (Exception e)
        {
            return;
        }

        var groupedLinks = Regex
            .Matches(pageHtml, @"<a href=""([\w\d./-:\#]+)"".*>(.*)</a>")
            .ToLookup(x => x.Value.Contains($"{page.Host}") || x.Groups[1].Value[0] == '/');

        if (groupedLinks[false].Any()) NotifyObservers(groupedLinks[false], page);

        var root = $"{page.Scheme}://{page.Authority}";

        foreach (var localLinkMatch in groupedLinks[true])
        {
            var localLink = localLinkMatch.Groups[1].Value;
            var nextUri = localLink.StartsWith('/') ? new Uri(root + localLink + '/') : new Uri(localLink + '/');
            Load(nextUri, --count);
        }
    }

    /// <summary>
    /// Метод уведомляет подписчиков о новых найденых внешних ссылках
    /// </summary>
    /// <param name="collection">Подходящие ссылки</param>
    /// <param name="page">Uri страницы на которой они были найдены</param>
    private void NotifyObservers(IEnumerable<Match> collection, Uri page)
    {
        ExternalLinkFoundEvent?.Invoke(
            collection
                .Select(match => new Link
                {
                    RootPageUri = $"{page}",
                    ExternalUri = match.Groups[1].Value,
                    Title = match.Groups[2].Value,
                    Level = _currentLevel
                }).ToArray()
        );
    }

    /// <summary>
    /// Метод запускает сканирование страницы
    /// </summary>
    /// <param name="startPage">Url адрес сканируемой страницы</param>
    /// <param name="pageCount">Количество страниц, которые нужно отсканировать</param>
    public void Start(string startPage, int pageCount)
    {
        _procLinks.Clear();
        _currentLevel = 0;
        Load(new Uri(startPage), pageCount);
        LoadingEndEvent?.Invoke();
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}