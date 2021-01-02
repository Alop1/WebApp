using System.IO;
using System.Text.Json;

namespace WebApp.Pages
{
    public class OpenHoursHandler
    {
        private string path = "./openHours.json";
        public OpenHours Get()
        {
            var jsonString = File.ReadAllText(path);
            OpenHours lastNews = JsonSerializer.Deserialize<OpenHours>(jsonString);
            return lastNews;
        }

        public void Save(OpenHours openHours)
        {
            var jsonString = JsonSerializer.Serialize<OpenHours>(openHours);
            File.WriteAllText(path, jsonString);
        }
    }
}
