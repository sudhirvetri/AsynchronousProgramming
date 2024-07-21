using System;
using System.Collections.Generic;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var watch = System.Diagnostics.Stopwatch.StartNew();
        RunDownloadSync();
        watch.Stop();
        var elapsedms = watch.ElapsedMilliseconds;
        Console.WriteLine("elapsedms:" + elapsedms);
    }

    private static List<string> PrepData()
    {
        List<string> data = new List<string>
        {
            "https://www.google.com",
            "https://www.yahoo.com/",
            "https://www.microsoft.com/en-in/",
            "https://edition.cnn.com/",
            "https://www.apple.com/"

        };

        return data;
    }

    private static WebsiteDataModel DownloadWebsite(string site)
    {
        WebsiteDataModel output = new WebsiteDataModel();
        using (WebClient client = new WebClient())
        {
            output.WebsiteUrl = site;
            output.WebsiteData = client.DownloadString(site);
        }
        return output;
    }

    private static void ReportWebsiteInfo(WebsiteDataModel data)
    {
        var result = $"{data.WebsiteUrl} downloaded: {data.WebsiteData.Length} characters long.{Environment.NewLine}";
        Console.WriteLine(result);
    }

    private static void RunDownloadSync()
    {
        List<string> websites = PrepData();

        foreach (string site in websites)
        {
            WebsiteDataModel results = DownloadWebsite(site);
            ReportWebsiteInfo(results);
        }
    }
}

class WebsiteDataModel
{
    public string WebsiteUrl { get; set; } = "";
    public string WebsiteData { get; set; } = "";
}