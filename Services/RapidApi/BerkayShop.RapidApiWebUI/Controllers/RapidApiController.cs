using BerkayShop.RapidApiWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BerkayShop.RapidApiWebUI.Controllers
{
    public class RapidApiController : Controller
    {
        private readonly HttpClient _httpClient;

        public RapidApiController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
             return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string city)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://the-weather-api.p.rapidapi.com/api/weather/{city}"),
                Headers =
            {
                { "x-rapidapi-key", "dc9c0c8a78mshf90c67ec1516768p1f4e66jsn40c8c6d60e9f" },
                { "x-rapidapi-host", "the-weather-api.p.rapidapi.com" },
            },
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var jsondata = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<WeatherModel>(jsondata);
                return View(value);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ExchangeRates()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=en"),
                Headers =
                    {
                        { "x-rapidapi-key", "dc9c0c8a78mshf90c67ec1516768p1f4e66jsn40c8c6d60e9f" },
                        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
                    },
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var UsdRates = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ExchangeRatesViewModel.Rootobject>(UsdRates);
                ViewBag.exchange_rateUsd = value.data.exchange_rate;
                ViewBag.previous_closeUsd = value.data.previous_close;
            }

            var request1 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=EUR&to_symbol=TRY&language=en"),
                Headers =
                {
                    { "x-rapidapi-key", "dc9c0c8a78mshf90c67ec1516768p1f4e66jsn40c8c6d60e9f" },
                    { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
                },
            };
            using (var response = await _httpClient.SendAsync(request1))
            {
                response.EnsureSuccessStatusCode();
                var euroRates = await response.Content.ReadAsStringAsync();
                var value2 = JsonConvert.DeserializeObject<ExchangeRatesViewModel.Rootobject>(euroRates);
                ViewBag.exchange_rateEur = value2.data.exchange_rate;
                ViewBag.previous_closeEur = value2.data.previous_close;
            }
            return View();
        }
    }
}
