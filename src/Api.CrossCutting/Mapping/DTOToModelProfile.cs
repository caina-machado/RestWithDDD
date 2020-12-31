using AutoMapper;
using src.Api.Domain.DTOs.User;
using src.Api.Domain.Models;

namespace src.Api.CrossCutting.Mapping
{
    public class DTOToModelProfile : Profile
    {
        public DTOToModelProfile()
        {
            CreateMap<UserDTO, UserModel>().ReverseMap();

            CreateMap<CreateUserDTO, UserModel>().ReverseMap();

            CreateMap<UpdateUserDTO, UserModel>().ReverseMap();
        }
    }
}
