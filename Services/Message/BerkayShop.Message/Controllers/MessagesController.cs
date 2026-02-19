using BerkayShop.Message.Dtos;
using BerkayShop.Message.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public MessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            var values = await _userMessageService.GetAllMessageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var message = await _userMessageService.GetMessageByIdAsync(id);
            return Ok(message);
        }

        [HttpGet("GetMessageForInbox/{receiverId}")]
        public async Task<IActionResult> GetMessageForInbox(string receiverId)
        {
            var ınboxMessages = await _userMessageService.GetAllInboxMessageAsync(receiverId);
            return Ok(ınboxMessages);
        }

        [HttpGet("GetMessageForSendbox/{senderId}")]
        public async Task<IActionResult> GetMessageForSendbox(string senderId)
        {
            var ınboxMessages = await _userMessageService.GetAllSendboxMessageAsync(senderId);
            return Ok(ınboxMessages);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto dto)
        {
            await _userMessageService.CreateMessageAsync(dto);
            return Ok("Ekleme İşlemi Başarıyla Gerçekleştirildi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto dto)
        {
            await _userMessageService.UpdateMessageAsync(dto);
            return Ok("Güncelleme İşlemi Başarıyla Gerçekleştirildi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Silme İşlemi Başarıyla Gerçekleştirildi");
        }
        [HttpGet("GetTotalMessageCount")]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            var count = await _userMessageService.GetTotalMessageCount();
            return Ok(count);
        }
        [AllowAnonymous]
        [HttpGet("GetMessageCountByUserId/{receiverId}")]
        public async Task<IActionResult> GetMessageCountByUserId(string receiverId)
        {
            var count = await _userMessageService.GetMessageCountByUserId(receiverId);
            return Ok(count);
        }
    }
}
