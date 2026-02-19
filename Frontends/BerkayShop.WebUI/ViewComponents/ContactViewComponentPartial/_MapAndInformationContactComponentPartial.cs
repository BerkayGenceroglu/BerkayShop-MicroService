using BerkayShop.DtoLayer.CatalogDtos.AboutDtos;
using BerkayShop.WebUI.Services.CatalogServices.AboutService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.ViewComponents.ContactViewComponentPartial
{
    public class _MapAndInformationContactComponentPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _MapAndInformationContactComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }
    }
}
