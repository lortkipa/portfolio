using Portfolio.Service.DTO;
using Portfolio.Service.DTO.About;
using Portfolio.Service.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.Interfaces
{
    public interface IAboutService
    {
        Task<IEnumerable<AboutDTO>> GetAllAsync();
        Task<AboutDTO> GetByIdAsync(int id);
        Task<AboutDTO> CreateAsync(CreateAboutDTO model);
        Task<bool> UpdateAsync(int id, UpdateAboutDTO model);
        Task<bool> DeleteAsync(int id);
    }
}
