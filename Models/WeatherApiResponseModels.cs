
namespace BlazorApp1.Models;

public class ForecastResponse
{
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public List<DailyForecast> Daily { get; set; } = new();
}

public class DailyForecast
{
    public DateTime Date { get; set; }
    public Temperature Temp { get; set; } = new();
    public double Humidity { get; set; }
    public double UvIndex { get; set; }
    public double WindSpeed { get; set; }
    public WeatherCondition[] Weather { get; set; } = Array.Empty<WeatherCondition>();
}

public class Temperature
{
    public double Day { get; set; }
    public double Min { get; set; }
    public double Max { get; set; }
    public double Night { get; set; }
    public double Eve { get; set; }
    public double Morn { get; set; }
}

public class WeatherCondition
{
    public string Main { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}

// OpenWeatherMap One Call API Response Models
public class OneCallResponse
{
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string Timezone { get; set; } = string.Empty;
    public DailyWeatherData[] Daily { get; set; } = Array.Empty<DailyWeatherData>();
}

public class DailyWeatherData
{
    public long Dt { get; set; }
    public DailyTemp Temp { get; set; } = new();
    public double Humidity { get; set; }
    public double Uvi { get; set; }
    public double Wind_Speed { get; set; }
    public WeatherInfo[] Weather { get; set; } = Array.Empty<WeatherInfo>();
}

public class DailyTemp
{
    public double Day { get; set; }
    public double Min { get; set; }
    public double Max { get; set; }
    public double Night { get; set; }
    public double Eve { get; set; }
    public double Morn { get; set; }
}

public class WeatherInfo
{
    public string Main { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}