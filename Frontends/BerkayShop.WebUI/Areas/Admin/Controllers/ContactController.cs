using BerkayShop.DtoLayer.CatalogDtos.ContactDtos;
using BerkayShop.WebUI.Services.CatalogServices.ContactService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> ContactList()
        {
            ViewBag.MainTitle = "Mesaj İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Mesajlar";
            ViewBag.Title3 = "Mesaj Listesi";

            var values = await _contactService.GetAllContactAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddContact()
        {
            ViewBag.MainTitle = "Mesaj İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Mesajlar";
            ViewBag.Title3 = "Mesaj Ekle";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(CreateContactDto createContactDto)
        {
            await _contactService.CreateContactAsync(createContactDto);
            return RedirectToAction("ContactList", "Contact", new { Area = "Admin" });
           
        }
        public async Task<IActionResult> RemoveContact(string id)
        {
             await _contactService.DeleteContactAsync(id);
            return RedirectToAction("ContactList", "Contact", new { Area = "Admin" });
           
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(string id)
        {
            ViewBag.MainTitle = "Mesaj İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Mesajlar";
            ViewBag.Title3 = "Mesaj Güncelle";

            var value =await _contactService.GetByIdContactAsync(id);
            var UpdateContactValue = new UpdateContactDto
            {
                ContactId = value.ContactId,
                NameSurname = value.NameSurname,
                Email = value.Email,
                Subject = value.Subject,
                Message = value.Message,
                IsRead = value.IsRead,
                SendDate = value.SendDate
            };
            return View(UpdateContactValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto dto)
        {
            await _contactService.UpdateContactAsync(dto);
            return RedirectToAction("ContactList", "Contact", new { Area = "Admin" });
        }
    }
}
