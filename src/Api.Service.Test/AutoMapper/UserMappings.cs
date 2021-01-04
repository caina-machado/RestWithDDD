using System;
using src.Api.Domain.DTOs.User;
using src.Api.Domain.Entities;
using src.Api.Domain.Models;
using Xunit;

namespace src.Api.Service.Test.AutoMapper
{
    public class UserMappings : BaseTest
    {
        [Fact(DisplayName = "Testing automapper mappings")]
        public void IsPossibleToCompleteMappings()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            var entity = Mapper.Map<UserEntity>(model);
            Assert.Equal(model.Id, entity.Id);
            Assert.Equal(model.Name, entity.Name);
            Assert.Equal(model.Email, entity.Email);
            Assert.Equal(model.CreateAt, entity.CreateAt);
            Assert.Equal(model.UpdateAt, entity.UpdateAt);

            var userDto = Mapper.Map<UserDTO>(entity);
            Assert.Equal(entity.Id, userDto.Id);
            Assert.Equal(entity.Name, userDto.Name);
            Assert.Equal(entity.Email, userDto.Email);

            var userCreateResultDto = Mapper.Map<UserCreateResultDTO>(entity);
            Assert.Equal(entity.Id, userCreateResultDto.Id);
            Assert.Equal(entity.Name, userCreateResultDto.Name);
            Assert.Equal(entity.Email, userCreateResultDto.Email);
            Assert.Equal(entity.CreateAt, userCreateResultDto.CreateAt);

            var userUpdateResultDto = Mapper.Map<UserUpdateResultDTO>(entity);
            Assert.Equal(entity.Id, userCreateResultDto.Id);
            Assert.Equal(entity.Name, userCreateResultDto.Name);
            Assert.Equal(entity.Email, userCreateResultDto.Email);
            Assert.Equal(entity.CreateAt, userCreateResultDto.CreateAt);

            var userModelFromUserDto = Mapper.Map<UserModel>(userDto);
            Assert.Equal(userDto.Id, userModelFromUserDto.Id);
            Assert.Equal(userDto.Name, userModelFromUserDto.Name);
            Assert.Equal(userDto.Email, userModelFromUserDto.Email);

            var createUserDTO = new CreateUserDTO
            {
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };

            var userModelFromCreateUserDto = Mapper.Map<UserModel>(createUserDTO);
            Assert.Equal(createUserDTO.Name, userModelFromCreateUserDto.Name);
            Assert.Equal(createUserDTO.Email, userModelFromCreateUserDto.Email);

            var updateUserDto = new UpdateUserDTO
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };

            var userModelFromUpdateUserDto = Mapper.Map<UserModel>(updateUserDto);
            Assert.Equal(updateUserDto.Id, userModelFromUpdateUserDto.Id);
            Assert.Equal(updateUserDto.Name, userModelFromUpdateUserDto.Name);
            Assert.Equal(updateUserDto.Email, userModelFromUpdateUserDto.Email);
        }
    }
}
