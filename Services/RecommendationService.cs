// BlazorApp1/Services/RecommendationService.cs
using BlazorApp1.Models;


namespace BlazorApp1.Services
{
    public interface IRecommendationService
    {
        List<WeatherRecommendation> GetRecommendations(WeatherResponse weather);
    }


    public class RecommendationService : IRecommendationService
    {
        public List<WeatherRecommendation> GetRecommendations(WeatherResponse weather)
        {
            if (weather == null || weather.Main == null || weather.Weather == null || weather.Weather.Length == 0)
            {
                return new List<WeatherRecommendation>();
            }


            double temperature = weather.Main.Temp;
            string weatherCondition = weather.Weather[0].Main?.ToLower() ?? "";
            
            // Get recommendations based on temperature and weather condition
            return GenerateRecommendations(temperature, weatherCondition);
        }


        private List<WeatherRecommendation> GenerateRecommendations(double temperature, string weatherCondition)
        {
            var recommendations = new List<WeatherRecommendation>();


            // Hot and sunny weather (80°F and above)
            if (temperature >= 80 && (weatherCondition.Contains("clear") || weatherCondition.Contains("sun")))
            {
                recommendations.Add(new WeatherRecommendation { Description = "It's hot and sunny outside!", Activity = "Wear sunscreen!" });
                recommendations.Add(new WeatherRecommendation { Description = "Stay cool and hydrated", Activity = "Make sure to stay hydrated!" });
                recommendations.Add(new WeatherRecommendation { Description = "Perfect for water activities", Activity = "Today would be a great day for a swim." });
                recommendations.Add(new WeatherRecommendation { Description = "Enjoy the outdoors", Activity = "It's a great day for a picnic!" });
                recommendations.Add(new WeatherRecommendation { Description = "Light exercise", Activity = "It's a nice day for a morning or evening walk." });
            }
            // Warm weather (65-80°F)
            else if (temperature >= 65 && temperature < 80)
            {
                recommendations.Add(new WeatherRecommendation { Description = "Pleasant temperatures", Activity = "Perfect weather for outdoor sports like tennis or golf." });
                recommendations.Add(new WeatherRecommendation { Description = "Great for exploration", Activity = "Consider visiting a local park or garden." });
                recommendations.Add(new WeatherRecommendation { Description = "Ideal for exercise", Activity = "Great conditions for a bike ride or jog." });
                recommendations.Add(new WeatherRecommendation { Description = "Outdoor dining", Activity = "Enjoy a meal at an outdoor restaurant." });
                recommendations.Add(new WeatherRecommendation { Description = "Nature time", Activity = "Go bird watching or hiking on a nature trail." });
            }
            // Cool weather (50-65°F)
            else if (temperature >= 50 && temperature < 65)
            {
                recommendations.Add(new WeatherRecommendation { Description = "Light jacket weather", Activity = "Bring a light jacket for outdoor activities." });
                recommendations.Add(new WeatherRecommendation { Description = "Coffee weather", Activity = "Perfect temperature to enjoy a hot beverage outside." });
                recommendations.Add(new WeatherRecommendation { Description = "Photography opportunity", Activity = "Great conditions for outdoor photography." });
                recommendations.Add(new WeatherRecommendation { Description = "Moderate exercise", Activity = "Ideal weather for a longer hike or run." });
                recommendations.Add(new WeatherRecommendation { Description = "Garden time", Activity = "Good weather for gardening or yard work." });
            }
            // Cold weather (32-50°F)
            else if (temperature >= 32 && temperature < 50)
            {
                recommendations.Add(new WeatherRecommendation { Description = "Bundle up", Activity = "Wear layers when heading outside." });
                recommendations.Add(new WeatherRecommendation { Description = "Indoor-outdoor mix", Activity = "Visit a museum with outdoor exhibits." });
                recommendations.Add(new WeatherRecommendation { Description = "Warming treats", Activity = "Good day to enjoy hot chocolate or soup." });
                recommendations.Add(new WeatherRecommendation { Description = "Brisk activity", Activity = "A brisk walk will keep you warm and active." });
                recommendations.Add(new WeatherRecommendation { Description = "Photography", Activity = "Capture the crisp scenery with your camera." });
            }
            // Very cold weather (below 32°F)
            else if (temperature < 32)
            {
                recommendations.Add(new WeatherRecommendation { Description = "Freezing conditions", Activity = "Dress in warm layers if you must go outside." });
                recommendations.Add(new WeatherRecommendation { Description = "Indoor day", Activity = "Great day for indoor activities like reading or movies." });
                recommendations.Add(new WeatherRecommendation { Description = "Winter sports", Activity = "If there's snow, consider sledding or building a snowman." });
                recommendations.Add(new WeatherRecommendation { Description = "Warm beverages", Activity = "Enjoy hot drinks to stay warm." });
                recommendations.Add(new WeatherRecommendation { Description = "Home cooking", Activity = "Perfect day to cook a warm, hearty meal." });
            }


            // Additional recommendations based on specific weather conditions
            if (weatherCondition.Contains("rain"))
            {
                recommendations.Add(new WeatherRecommendation { Description = "Rainy day", Activity = "Don't forget your umbrella!" });
                recommendations.Add(new WeatherRecommendation { Description = "Indoor entertainment", Activity = "Visit a local museum or art gallery." });
                recommendations.Add(new WeatherRecommendation { Description = "Cozy activity", Activity = "Curl up with a good book and hot tea." });
                recommendations.Add(new WeatherRecommendation { Description = "Rainy day cooking", Activity = "Try baking something new in the kitchen." });
                recommendations.Add(new WeatherRecommendation { Description = "Movie time", Activity = "Perfect weather for a movie marathon." });
            }
            else if (weatherCondition.Contains("snow"))
            {
                recommendations.Add(new WeatherRecommendation { Description = "Snowy conditions", Activity = "Drive carefully if you need to travel." });
                recommendations.Add(new WeatherRecommendation { Description = "Winter fun", Activity = "Build a snowman or go sledding." });
                recommendations.Add(new WeatherRecommendation { Description = "Snow sports", Activity = "Great conditions for skiing or snowboarding if available." });
                recommendations.Add(new WeatherRecommendation { Description = "Warm indoors", Activity = "Enjoy the snow view from inside with hot chocolate." });
                recommendations.Add(new WeatherRecommendation { Description = "Photography", Activity = "Capture the beautiful snowy landscape." });
            }
            else if (weatherCondition.Contains("cloud"))
            {
                recommendations.Add(new WeatherRecommendation { Description = "Cloudy but dry", Activity = "Good conditions for a walk without sun glare." });
                recommendations.Add(new WeatherRecommendation { Description = "Outdoor activities", Activity = "The clouds provide natural shade for outdoor activities." });
                recommendations.Add(new WeatherRecommendation { Description = "Photography", Activity = "Cloudy days provide great diffused light for photos." });
                recommendations.Add(new WeatherRecommendation { Description = "Light layers", Activity = "Wear light layers as temperatures might fluctuate." });
                recommendations.Add(new WeatherRecommendation { Description = "Park visit", Activity = "Visit a local park without worrying about sunburn." });
            }
            else if (weatherCondition.Contains("wind"))
            {
                recommendations.Add(new WeatherRecommendation { Description = "Windy conditions", Activity = "Secure loose items outdoors." });
                recommendations.Add(new WeatherRecommendation { Description = "Kite flying", Activity = "Great day for flying a kite!" });
                recommendations.Add(new WeatherRecommendation { Description = "Wind protection", Activity = "Wear a windbreaker if heading outside." });
                recommendations.Add(new WeatherRecommendation { Description = "Indoor preference", Activity = "Consider indoor activities if the wind is strong." });
                recommendations.Add(new WeatherRecommendation { Description = "Nature sounds", Activity = "Listen to the wind in the trees at a local park." });
            }


            return recommendations;
        }
    }
}