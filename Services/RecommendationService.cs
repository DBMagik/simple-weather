using BlazorApp1.Models;


namespace BlazorApp1.Services
{
    public interface IRecommendationService
    {
        List<string> GetRecommendations(WeatherResponse? weather);
    }


    public class RecommendationService : IRecommendationService
    {
        public List<string> GetRecommendations(WeatherResponse? weather)
        {
            if (weather == null || weather.Main == null || weather.Weather == null || weather.Weather.Length == 0)
            {
                return new List<string>
                {
                    "Unable to generate recommendations without weather data.",
                    "Try entering a valid city to get started.",
                    "Stay safe and check the weather again soon!",
                    "Consider indoor activities if unsure.",
                    "Remember to dress appropriately for any conditions."
                };
            }


            var temp = weather.Main.Temp;
            var weatherType = weather.Weather[0].Main?.ToLower() ?? string.Empty;


            // Define categories with at least 5 recommendations each
            if (weatherType.Contains("clear") && temp > 75)
            {
                // Sunny and warm (based on your example for 80°F and sunny)
                return new List<string>
                {
                    "Wear sunscreen to protect your skin!",
                    "Make sure to stay hydrated with plenty of water!",
                    "Today would be a great day for a swim or beach outing.",
                    "It's a perfect day for a picnic in the park!",
                    "Enjoy a nice walk or hike in the sunshine.",
                    "Consider outdoor sports like biking or playing frisbee."
                };
            }
            else if (weatherType.Contains("rain") || weatherType.Contains("drizzle"))
            {
                // Rainy weather
                return new List<string>
                {
                    "Don't forget your umbrella or raincoat!",
                    "It's a great day for indoor activities like reading a book.",
                    "Stay dry and enjoy a movie marathon at home.",
                    "Try baking or cooking a comforting meal.",
                    "Visit a museum or indoor exhibit if you're out.",
                    "Relax with some hot tea and board games."
                };
            }
            else if (temp < 50)
            {
                // Cold weather (regardless of type, for broad coverage)
                return new List<string>
                {
                    "Bundle up with warm layers and a coat!",
                    "Stay cozy indoors with a hot drink.",
                    "It's a good day for winter sports like skiing if conditions allow.",
                    "Enjoy some hearty soup or warm meals.",
                    "Take a brisk walk, but dress for the chill.",
                    "Curl up with a blanket and watch the scenery."
                };
            }
            else
            {
                // Default for other conditions (e.g., cloudy, mild)
                return new List<string>
                {
                    "Check the forecast and plan accordingly!",
                    "A light jacket might be a good idea.",
                    "It's a fine day for casual outdoor activities.",
                    "Stay hydrated and enjoy the weather.",
                    "Consider a visit to a local park or cafe.",
                    "Relax and make the most of the day!"
                };
            }
        }
    }
}