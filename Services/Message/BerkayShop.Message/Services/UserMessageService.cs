using AutoMapper;
using BerkayShop.Message.DAL.Context;
using BerkayShop.Message.DAL.Entities;
using BerkayShop.Message.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BerkayShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;


        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            await _messageContext.UserMessages.AddAsync(_mapper.Map<UserMessage>(createMessageDto));
            await _messageContext.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var value = await _messageContext.UserMessages.FindAsync(id);
            _messageContext.UserMessages.Remove(value);
            await _messageContext.SaveChangesAsync();
        }

        public async Task<List<ResultInboxMessageDto>> GetAllInboxMessageAsync(string receiverId)
        {
            var values = await _messageContext.UserMessages.Where(x => x.ReceiverId == receiverId).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var values = await _messageContext.UserMessages.ToListAsync();
            var List = _mapper.Map<List<ResultMessageDto>>(values);
            return List;
        }

        public async Task<List<ResultSendboxMessageDto>> GetAllSendboxMessageAsync(string senderId)
        {
            var values = await _messageContext.UserMessages.Where(x => x.SenderId == senderId).ToListAsync();
            var List = _mapper.Map<List<ResultSendboxMessageDto>>(values);
            return List;
        }

        public async Task<ResultMessageDto> GetMessageByIdAsync(int id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.UserMessageId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultMessageDto>(values);
        }

        public async Task<int> GetMessageCountByUserId(string receiverId)
        {
            var count = await _messageContext.UserMessages.Where(x => x.ReceiverId == receiverId).CountAsync();
            return count;
        }

        public async Task<int> GetTotalMessageCount()
        {
            var totalMessageCount = await _messageContext.UserMessages.CountAsync();
            return totalMessageCount;
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var values = _mapper.Map<UserMessage>(updateMessageDto);
            _messageContext.UserMessages.Update(values);
            await _messageContext.SaveChangesAsync();
        }
    }
}
