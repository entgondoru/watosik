using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Watosik.Application.DataTransferObjects;
using Watosik.Domain.Entities;
using Watosik.Domain.Interfaces;

namespace Watosik.Infrastructure.Repositories
{
    public class WeatherAPIClient : IWeatherAPIClient
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "3daccd8241eaa13877bee95a79efbdcf";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherAPIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Weather> GetWeatherAsync(string city)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}?q={city}&appid={ApiKey}&units=metric");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Błąd podczas pobierania danych pogodowych: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            var weatherDto = JsonSerializer.Deserialize<WeatherDto>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Sprawdzenie na null i logowanie
            if (weatherDto == null || weatherDto.Main == null || weatherDto.Weather == null || !weatherDto.Weather.Any())
            {
                throw new NullReferenceException("Nie udało się uzyskać prawidłowej odpowiedzi z API pogodowego. Sprawdź miasto lub klucz API.");
            }

            return new Weather(weatherDto.Main.Temp, weatherDto.Main.Humidity, weatherDto.Weather[0].Description);
        }

    }
}
