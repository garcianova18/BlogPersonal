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
            CreateMap<ListPostVM, Post>().ReverseMap();
        }
    }
}
