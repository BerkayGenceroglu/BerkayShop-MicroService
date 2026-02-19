using BerkayShop.DtoLayer.CatalogDtos.CategoryDtos;
using BerkayShop.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol.Plugins;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Reflection.PortableExecutable;
using static System.Net.WebRequestMethods;

namespace BerkayShop.WebUI.Controllers
{
	public class TestController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryService;


        public TestController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
		{
            string token ="";
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost:5001/connect/token"),
                    Method = HttpMethod.Post,
                    //Dictionary= Birden fazla key → value çifti tutan koleksiyon
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"client_id","BerkayShopVisitorId" },
                        {"client_secret","BerkayShopVisitorSecret" },
                        {"grant_type","client_credentials" }
                    })
                };

                using (var response = await httpClient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var tokenResponse = JObject.Parse(content);
                        token = tokenResponse["access_token"]!.ToString();
                    }
                }
            }
            var client = _httpClientFactory.CreateClient();
            //HTTP isteğine kimlik doğrulama(authorization) bilgisi ekler.
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //HTTP’te:
            //Body → gönderilen veri
            //Header → isteğe ait bilgiler(kimlik, tür, format vs.)
            //Yetkilendirme → meta bilgi olduğu için header’a konur.
            var responseMessage = await client.GetAsync("https://localhost:7100/api/Categories");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
				return View(values);
			}
			return View();
		}

        public async Task<IActionResult> Deneme2()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
	}
}
