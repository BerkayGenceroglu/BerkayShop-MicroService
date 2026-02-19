using BerkayShop.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class ECommerceRapidApiController : Controller
    {
        private readonly HttpClient _httpClient;

        public ECommerceRapidApiController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost ]
        public async Task<IActionResult> Index(string product)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://real-time-product-search.p.rapidapi.com/search-v2?q={product}&country=tr&language=en&page=1&limit=15&sort_by=BEST_MATCH&product_condition=ANY&return_filters=true"),
                Headers =
                    {
                        { "x-rapidapi-key", "dc9c0c8a78mshf90c67ec1516768p1f4e66jsn40c8c6d60e9f" },
                        { "x-rapidapi-host", "real-time-product-search.p.rapidapi.com" },
                    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var jsondata = await response.Content.ReadAsStringAsync();
                var deserializedData = JsonConvert.DeserializeObject<RapidApiProductModel.Rootobject>(jsondata);
                return View(deserializedData.data);
            }
        }
    }
}
