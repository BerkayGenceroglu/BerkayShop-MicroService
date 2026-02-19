using AutoMapper;
using BerkayShop.Comment.Dtos.CommentDto;
using BerkayShop.Comment.Entities;

namespace BerkayShop.Comment.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            //Comment
            CreateMap<UserComment, ResultCommentDto>().ReverseMap();
            CreateMap<UserComment, UpdateCommentDto>().ReverseMap();
            CreateMap<UserComment, CreateCommentDto>().ReverseMap();
            CreateMap<UserComment, GetByIdCommentDto>().ReverseMap();
        }
    }
}
