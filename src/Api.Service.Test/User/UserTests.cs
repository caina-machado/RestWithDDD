using System;
using System.Collections.Generic;
using src.Api.Domain.DTOs.User;

namespace src.Api.Service.Test.User
{
    public class UserTests
    {
        public static Guid UserId { get; set; }
        public static string UserName { get; set; }
        public static string UserEmail { get; set; }
        public static string UserNameChanged { get; set; }
        public static string UserEmailChanged { get; set; }

        public List<UserDTO> userDtoList = new List<UserDTO>();
        public UserDTO userDto;
        public CreateUserDTO createUserDto;
        public UserCreateResultDTO userCreateResultDTO;
        public UpdateUserDTO updateUserDTO;
        public UserUpdateResultDTO userUpdateResultDTO;

        public UserTests()
        {
            UserId = Guid.NewGuid();
            UserName = Faker.Name.FullName();
            UserEmail = Faker.Internet.Email();
            UserNameChanged = Faker.Name.FullName();
            UserEmailChanged = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)

            {
                var dto = new UserDTO
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };

                userDtoList.Add(dto);
            }

            userDto = new UserDTO
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail
            };

            createUserDto = new CreateUserDTO
            {
                Name = UserName,
                Email = UserEmail
            };

            userCreateResultDTO = new UserCreateResultDTO
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                CreateAt = DateTime.Now
            };

            updateUserDTO = new UpdateUserDTO
            {
                Id = UserId,
                Name = UserNameChanged,
                Email = UserEmailChanged
            };

            userUpdateResultDTO = new UserUpdateResultDTO
            {
                Id = UserId,
                Name = UserNameChanged,
                Email = UserEmailChanged,
                UpdateAt = DateTime.Now
            };
        }
    }
}
