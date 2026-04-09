using Portfolio.Service.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateUserDTO model);
        Task<bool> UpdateAsync(int id, UpdateUserDTO model);
        Task<bool> DeleteAsync(int id);
    }
}
