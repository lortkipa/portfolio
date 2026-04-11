using Portfolio.Service.DTO.Skill;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillDTO>> GetAllAsync();
        Task<SkillDTO> GetByIdAsync(int id);
        Task<SkillDTO> CreateAsync(CreateSkillDTO model);
        Task<bool> UpdateAsync(int id, UpdateSkillDTO model);
        Task<bool> DeleteAsync(int id);
    }
}
