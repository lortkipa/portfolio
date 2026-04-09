using AutoMapper;
using Portfolio.Dal.Repositories;
using Portfolio.Data.Entities;
using Portfolio.Service.DTO.User;
using Portfolio.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(entities);
        }
        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) throw new Exception("entity not found");

            return _mapper.Map<UserDTO>(entity);
        }
        public async Task<bool> CreateAsync(CreateUserDTO model)
        {
            if (model == null) return false;

            var entity = _mapper.Map<User>(model);
            await _repo.AddAsync(entity);
            return _mapper.Map<UserDTO>(entity) != null;
        }
        public async Task<bool> UpdateAsync(int id, UpdateUserDTO model)
        {
            if (model == null) return false;

            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(model, entity);
            await _repo.UpdateAsync(entity);
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;

            await _repo.DeleteAsync(id);
            return true;
        }
    }
}
