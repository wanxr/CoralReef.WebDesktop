using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Vue3_Vite.Entities;
using Vue3_Vite.Helper;

namespace Vue3_Vite.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<WeatherForecast> GetWeather()
        {
            return GenerateWeathers();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetWeatherAllowAnonymous()
        {
            return GenerateWeathers();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetWeatherAllowAnonymous2()
        {
            throw new Exception("This is a test");
        }

        private IEnumerable<WeatherForecast> GenerateWeathers()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}