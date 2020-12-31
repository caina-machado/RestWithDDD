using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.Api.Domain.DTOs.User;

namespace src.Api.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> FindAllAsync();
        Task<UserDTO> FindByIdAsync(Guid id);
        Task<UserInsertResultDTO> InsertAsync(CreateUserDTO userDTO);
        Task<UserUpdateResultDTO> UpdateAsync(UpdateUserDTO userDTO);
        Task<bool> DeleteAsync(Guid id);
    }
}
