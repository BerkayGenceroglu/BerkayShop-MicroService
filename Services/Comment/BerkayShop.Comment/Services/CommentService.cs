using AutoMapper;
using BerkayShop.Comment.Context;
using BerkayShop.Comment.Dtos.CommentDto;
using BerkayShop.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace BerkayShop.Comment.Services
{
    public class CommentService : ICommentService
    {
        private readonly CommentContext _context;
        private readonly IMapper _mapper;

        public CommentService(CommentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            var value = _mapper.Map<UserComment>(createCommentDto);
            await _context.UserComments.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int id)
        {
            var value = await _context.UserComments.FindAsync(id);
            if (value != null)
            {
                _context.UserComments.Remove(value);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetActiveCommentCountAsync()
        {
            var activeCommentCount = await _context.UserComments.CountAsync(x => x.Status == true);
            return activeCommentCount;
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var values = await _context.UserComments.ToListAsync();
            return _mapper.Map<List<ResultCommentDto>>(values);
        }

        public async Task<GetByIdCommentDto> GetByIdCommentAsync(int id)
        {
            var value = await _context.UserComments.FindAsync(id);
            return _mapper.Map<GetByIdCommentDto>(value);
        }

        public async Task<List<ResultCommentDto>> GetByProductIdCommentAsync(string productId)
        {
            var value = await _context.UserComments.Where(x => x.ProductId == productId).ToListAsync();
            return _mapper.Map<List<ResultCommentDto>>(value);
        }

        public async Task<int> GetPassiveCommentCountAsync()
        {
            var passiveCommentCount = await _context.UserComments.CountAsync(x => x.Status == false);
            return passiveCommentCount;
        }

        public async Task<int> GetTotalCommentCountAsync()
        {
             var totalCount = await _context.UserComments.CountAsync();
             return totalCount;
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            var value = _mapper.Map<UserComment>(updateCommentDto);
            _context.UserComments.Update(value);
            await _context.SaveChangesAsync();
        }
    }
}
