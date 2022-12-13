using SusuLabs.Lab4.Data;
using SusuLabs.Lab4.Data.Entities;

namespace SusuLabs.Lab4;

public static class Program
{
    private const string FilePath = "";
    private static readonly List<Link> Links = new();

    [Obsolete("Obsolete")]
    public static void Main(string[] args)
    { 
        var loader = new LinkLoader();
        loader.ExternalLinkFoundEvent += PrintLinks;
        loader.LoadingEndEvent += WriteToCvs;
        
        loader.Start("https://www.msu.ru/", 10);
    }

    private static void PrintLinks(Link[] links)
    {
        Links.AddRange(links);
        
        foreach (var link in links)
        {
            Console.WriteLine($"On page {link.RootPageUri} " +
                              $"found external link {link.ExternalUri} " +
                              $"with title {link.Title}." +
                              $" (Level {link.Level})");
        }
    }

    private static void WriteToCvs()
    {
        CvsWriter.Write(Links, "C://Temp/external links.csv");
    }
}