using Portfolio.Data.Entities;
using Portfolio.Service.DTO.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDTO>> GetAllAsync();
        Task<MessageDTO> GetByIdAsync(int id);
        Task<MessageDTO> CreateAsync(CreateMessageDTO model);
        Task<bool> UpdateAsync(int id, UpdateMessageDTO model);
        Task<bool> DeleteAsync(int id);
    }
}
