using Portfolio.Service.DTO.SkillTag;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.Interfaces
{
    public interface ISkillTagService
    {
        Task<IEnumerable<SkillTagDTO>> GetAllAsync();
        Task<SkillTagDTO> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateSkillTagDTO model);
        Task<bool> UpdateAsync(int id, UpdateSkillTagDTO model);
        Task<bool> DeleteAsync(int id);
        Task<bool> AddTag(int skillId, int tagId);
        Task<bool> RemoveTag(int skillId, int tagId);
    }
}
