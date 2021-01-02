using System.IO;
using System.Text.Json;

namespace WebApp.Pages
{
    public class NewsHandler
    {
        public string newsPath = "./NewsSource.json";

        
        public News GetNews()
        {
            var jsonString = File.ReadAllText(newsPath);
            News lastNews = JsonSerializer.Deserialize<News>(jsonString);
            return lastNews;
        }

        public void SaveNews(News news)
        {
            var jsonString = JsonSerializer.Serialize<News>(news);
            File.WriteAllText(newsPath, jsonString);
        }
    }
}
