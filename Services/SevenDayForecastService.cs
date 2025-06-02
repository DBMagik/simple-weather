using BlazorApp1.Models;
using System.Text.Json;

namespace BlazorApp1.Services;

public class ForecastService : IForecastService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public ForecastService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<ForecastResponse?> GetSevenDayForecastAsync(string cityName)
    {
        var apiKey = _configuration["OpenWeatherMap:ApiKey"];
        
        if (string.IsNullOrEmpty(apiKey))
        {
            throw new InvalidOperationException("OpenWeatherMap API key is not configured");
        }

        try
        {
            // First, get coordinates for the city
            var geoUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={cityName}&limit=1&appid={apiKey}";
            var geoResponse = await _httpClient.GetStringAsync(geoUrl);
            var geoData = JsonSerializer.Deserialize<GeoLocation[]>(geoResponse);

            if (geoData == null || geoData.Length == 0)
            {
                return null;
            }

            var location = geoData[0];

            // Get 7-day forecast using One Call API
            var forecastUrl = $"https://api.openweathermap.org/data/2.5/onecall?lat={location.Lat}&lon={location.Lon}&exclude=current,minutely,hourly,alerts&appid={apiKey}&units=imperial";
            var forecastResponse = await _httpClient.GetStringAsync(forecastUrl);
            var forecastData = JsonSerializer.Deserialize<OneCallResponse>(forecastResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (forecastData?.Daily == null)
            {
                return null;
            }

            // Convert to our model
            var forecast = new ForecastResponse
            {
                City = location.Name,
                Country = location.Country,
                Daily = forecastData.Daily.Take(7).Select(day => new DailyForecast
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(day.Dt).DateTime,
                    Temp = new Temperature
                    {
                        Day = day.Temp.Day,
                        Min = day.Temp.Min,
                        Max = day.Temp.Max,
                        Night = day.Temp.Night,
                        Eve = day.Temp.Eve,
                        Morn = day.Temp.Morn
                    },
                    Humidity = day.Humidity,
                    UvIndex = day.Uvi,
                    WindSpeed = day.Wind_Speed,
                    Weather = day.Weather.Select(w => new WeatherCondition
                    {
                        Main = w.Main,
                        Description = w.Description,
                        Icon = w.Icon
                    }).ToArray()
                }).ToList()
            };

            return forecast;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error fetching forecast data: {ex.Message}", ex);
        }
    }
}

public class GeoLocation
{
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public double Lat { get; set; }
    public double Lon { get; set; }
}