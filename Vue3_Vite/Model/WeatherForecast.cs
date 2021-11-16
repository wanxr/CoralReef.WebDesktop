using System;
using System.Text.Json.Serialization;

namespace Vue3_Vite.Model
{
    public class WeatherForecast
    {
        private int temperature;

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("temperature")]
        public int TemperatureC
        {
            get
            {
                return 32 + (int)(temperature / 0.5556);
            }
            set
            {
                temperature = value;
            }
        }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }
    }
}