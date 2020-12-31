using System;

namespace src.Api.Domain.DTOs.User
{
    public class UserUpdateResultDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
