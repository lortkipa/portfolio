using Portfolio.Service.DTO.Tag;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<TagDTO>> GetAllAsync();
        Task<TagDTO> GetByIdAsync(int id);
        Task<TagDTO> CreateAsync(CreateTagDTO model);
        Task<bool> UpdateAsync(int id, UpdateTagDTO model);
        Task<bool> DeleteAsync(int id);
    }
}
