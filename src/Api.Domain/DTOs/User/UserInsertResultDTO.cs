using System;

namespace src.Api.Domain.DTOs.User
{
    public class UserInsertResultDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
