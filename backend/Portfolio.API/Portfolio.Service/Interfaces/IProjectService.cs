using Portfolio.Service.DTO.Project;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDTO>> GetAllAsync();
        Task<ProjectDTO> GetByIdAsync(int id);
        Task<ProjectDTO> CreateAsync(CreateProjectDTO model);
        Task<bool> UpdateAsync(int id, UpdateProjectDTO model);
        Task<bool> DeleteAsync(int id);
    }
}
