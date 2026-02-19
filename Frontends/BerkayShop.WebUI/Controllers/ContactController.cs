using BerkayShop.DtoLayer.CatalogDtos.ContactDtos;
using BerkayShop.WebUI.Services.CatalogServices.ContactService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace BerkayShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult ContactPage()
        {
            ViewBag.Directory1 = "BerkayShop";
            ViewBag.Directory2 = "İletişim";
            ViewBag.Directory3 = "Bize Ulaşın";
            return View();
        }

        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {
            createContactDto.SendDate = DateTime.Now;
            createContactDto.IsRead = false;
            await _contactService.CreateContactAsync(createContactDto);
            return RedirectToAction("ContactPage", "Contact");
        }
    }
}
