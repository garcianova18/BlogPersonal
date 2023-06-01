using AutoMapper;
using Dominio.Models;
using DTOs.DTO;
    

namespace BlogPersonal
{
    public class ProfileConfig: Profile
    {
        public ProfileConfig()
        {
            CreateMap<CreatePostVM, Post>().ReverseMap();
            CreateMap<PostVM, Post>().ReverseMap();
            CreateMap<EditPostVM, Post>().ReverseMap();
            CreateMap<DetailsPostVM, Post>().ForMember(src=> src.Comentarios, op => op.MapFrom(des=> des.ListComentarios)).ReverseMap();
            CreateMap<UserLoginVM, User>().ReverseMap();
           


        }
    }
}
