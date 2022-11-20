using System.Net;
using Newtonsoft.Json;

namespace AsyncHomework
{
    internal class Program
    {
        static string cityName = "Odessa";
        static readonly string URL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=metric&appid=642486029ae6aec1a5b402c0efdc47d7";

        static async Task Main(string[] args)
        {
            Console.Write("Enter city name: ");
            cityName = Console.ReadLine()!;
            
            await GetTempByCityAsync(URL, cityName);
        }

        static async Task GetTempByCityAsync(string url, string city)
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);

            WeatherResponse ?weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
            Console.WriteLine($"In {city} - {weatherResponse!.Main.Temp} now");
        }
    }
}
//checked
