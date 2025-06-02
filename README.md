# Blazor Weather App

A simple weather application built with Blazor Server that displays current weather information using the OpenWeatherMap API.

## Features

- Current weather data display
- Temperature, feels like, min/max temperatures
- Humidity and pressure information
- Clean, responsive UI built with Blazor components

## Prerequisites

- .NET 9.0 SDK
- Visual Studio 2022 or JetBrains Rider (recommended)
- Internet connection for API calls

## Getting Started

### 1. Clone or Extract the Project
Extract the project files to your desired location. (This project or future projects will be made public on GitHub so it can be cloned easily through [DBMagik](https://github.com/DBMagik?tab=repositories))

### 2. API Key Configuration
The project includes a working API key in `appsettings.Development.json` for testing purposes. You can use this key to run the application immediately.

**If the included API key fails or you need your own:**
1. Visit [OpenWeatherMap API](https://openweathermap.org/api)
2. Sign up for a free account
3. Get your API key from the "One Call API 2.5" (not 3.0)
4. Replace the `ApiKey` value in `appsettings.Development.json`: