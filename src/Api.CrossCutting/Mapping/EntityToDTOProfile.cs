using AutoMapper;
using src.Api.Domain.DTOs.User;
using src.Api.Domain.Entities;

namespace src.Api.CrossCutting.Mapping
{
    public class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap<UserEntity, UserDTO>().ReverseMap();

            CreateMap<UserEntity, UserCreateResultDTO>().ReverseMap();

            CreateMap<UserEntity, UserUpdateResultDTO>().ReverseMap();
        }
    }
}
