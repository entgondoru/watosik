using MediatR;
using Microsoft.AspNetCore.Mvc;
using Watosik.Domain.Interfaces;

namespace Watosik.MVC.Views.Shared.Components
{
    public class WeatherViewComponent : ViewComponent
    {
        private readonly IWeatherAPIClient _weatherApiClient;

        public WeatherViewComponent(IWeatherAPIClient weatherApiClient)
        {
            _weatherApiClient = weatherApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(string city = "Warsaw")
        {
            var weather = await _weatherApiClient.GetWeatherAsync(city);
            float temp = weather.Temperature;
            string outfit;
            if(temp < 5)
    {
                outfit = "Kurtka, czapka, rękawiczki";
            }
            else if (temp <= 15)
            {
                outfit = "Kurtka, beret";
            }
            else if (temp <= 25)
            {
                outfit = "Mundur polowy, beret";
            }
            else
            {
                outfit = "Koszula wojskowa, beret";
            }
            ViewBag.WeatherOutfit = outfit;
            return View(weather);
        }
    }
}
