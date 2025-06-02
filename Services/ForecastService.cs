using BlazorApp1.Models;

namespace BlazorApp1.Services;

public interface IForecastService
{
    Task<ForecastResponse?> GetSevenDayForecastAsync(string cityName);
}