using Portfolio.Service.DTO.ProjectTag;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.Interfaces
{
    public interface IProjectTagService
    {
        Task<IEnumerable<ProjectTagDTO>> GetAllAsync();
        Task<ProjectTagDTO> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateProjectTagDTO model);
        Task<bool> UpdateAsync(int id, UpdateProjectTagDTO model);
        Task<bool> DeleteAsync(int id);
    }
}
