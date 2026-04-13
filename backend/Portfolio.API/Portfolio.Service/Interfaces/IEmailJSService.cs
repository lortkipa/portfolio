using Portfolio.Service.DTO.EmailJS;
using Portfolio.Service.DTO.Skill;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.Interfaces
{
    public interface IEmailJSService
    {
        Task<IEnumerable<EmailJSDTO>> GetAllAsync();
        Task<EmailJSDTO> GetByIdAsync(int id);
        Task<EmailJSDTO> CreateAsync(CreateEmailJSDTO model);
        Task<bool> UpdateAsync(int id, UpdateEmailJSDTO model);
        Task<bool> DeleteAsync(int id);
    }
}
