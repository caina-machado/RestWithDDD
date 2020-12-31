using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using src.Api.Domain.DTOs.User;
using src.Api.Domain.Entities;
using src.Api.Domain.Interfaces;
using src.Api.Domain.Interfaces.Services;
using src.Api.Domain.Models;

namespace src.Api.Service.Services.User
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> FindAllAsync()
        {
            var entities = await _repository.FindAllAsync();

            return _mapper.Map<IEnumerable<UserDTO>>(entities);
        }

        public async Task<UserDTO> FindByIdAsync(Guid id)
        {
            var entity = await _repository.FindByIdAsync(id);

            return _mapper.Map<UserDTO>(entity);
        }

        public async Task<UserCreateResultDTO> InsertAsync(CreateUserDTO userDTO)
        {
            var model = _mapper.Map<UserModel>(userDTO);
            var user = _mapper.Map<UserEntity>(model);

            var entity = await _repository.InsertAsync(user);

            return _mapper.Map<UserCreateResultDTO>(entity);
        }

        public async Task<UserUpdateResultDTO> UpdateAsync(UpdateUserDTO userDTO)
        {
            var model = _mapper.Map<UserModel>(userDTO);
            var user = _mapper.Map<UserEntity>(model);

            var entity = await _repository.InsertAsync(user);

            return _mapper.Map<UserUpdateResultDTO>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
