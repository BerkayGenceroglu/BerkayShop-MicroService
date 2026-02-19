using BerkayShop.DtoLayer.CatalogDtos.ContactDtos;

namespace BerkayShop.WebUI.Services.CatalogServices.ContactService
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync("Contacts", createContactDto);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync($"Contacts/{id}");
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultContactDto>>("Contacts");
            return values;
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<GetByIdContactDto>($"Contacts/{id}");
            return value!;
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync("Contacts", updateContactDto);
        }
    }
}
