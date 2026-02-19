using BerkayShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using BerkayShop.WebUI.Services.CatalogServices.SpecialOfferService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.ViewComponents.DefaultViewComponetPartial
{
    public class _SpecialOfferDefaultComponentPartial:ViewComponent
    {
       private readonly ISpecialOfferService _specialOfferService;

        public _SpecialOfferDefaultComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(value);
        }
    }
}
