using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace GithubActionsDemo.Controllers
{
    internal static class WeatherData
    {
        public static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }

    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("/WeatherForecast", Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = WeatherData.Summaries[Random.Shared.Next(WeatherData.Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/weather/hourly", Name = "GetHourlyForecast")]
        public IEnumerable<WeatherForecast> GetHourly()
        {
            return Enumerable.Range(1, 24).Select(hour => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddHours(hour)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = WeatherData.Summaries[Random.Shared.Next(WeatherData.Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/weather/summaries", Name = "GetSummaries")]
        public IEnumerable<string> GetSummaries()
        {
            return WeatherData.Summaries;
        }
    }
}
