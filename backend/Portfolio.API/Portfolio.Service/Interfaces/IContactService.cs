using Portfolio.Service.DTO.Contact;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDTO>> GetAllAsync();
        Task<ContactDTO> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateContactDTO model);
        Task<bool> UpdateAsync(int id, UpdateContactDTO model);
        Task<bool> DeleteAsync(int id);
    }
}
