using AutoMapper;
using Portfolio.Dal.Repositories;
using Portfolio.Data.Entities;
using Portfolio.Service.DTO;
using Portfolio.Service.DTO.User;
using Portfolio.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Portfolio.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IContactRepository _contactRepo;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _hasher;

        public UserService(IUserRepository repo, IContactRepository contactRepo, IMapper mapper, IPasswordHasher hasher)
        {
            _repo = repo;
            _contactRepo = contactRepo;
            _mapper = mapper;
            _hasher = hasher;
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
        public async Task<UserDTO> GetByEmailAsync(string email)
        {
            var entity = await _repo.GetByEmailAsync(email);
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
        public async Task<AuthResponseDTO> LoginAsync(LoginUserDTO model)
        {
            var user = await _repo.GetByEmailAsync(model.Email);
            if (user == null)
                return new AuthResponseDTO { Status = false, Message = "Invalid Email or Password" };

            if (await _hasher.VerifyPassword(model.Password, user.PasswordHash) == false)
                return new AuthResponseDTO { Status = false, Message = "Invalid Email or Password" };

            return new AuthResponseDTO { Status = true, Message = "Login was successful" };
        }
    }
}
