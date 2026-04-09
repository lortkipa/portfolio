using AutoMapper;
using Portfolio.Dal.Repositories;
using Portfolio.Data.Entities;
using Portfolio.Service.DTO.Contact;
using Portfolio.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDTO>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ContactDTO>>(entities);
        }
        public async Task<ContactDTO> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) throw new Exception("entity not found");

            return _mapper.Map<ContactDTO>(entity);
        }
        public async Task<bool> CreateAsync(CreateContactDTO model)
        {
            if (model == null) return false;

            var entity = _mapper.Map<Contact>(model);
            await _repo.AddAsync(entity);
            return _mapper.Map<ContactDTO>(entity) != null;
        }
        public async Task<bool> UpdateAsync(int id, UpdateContactDTO model)
        {
            if (model == null) return false;

            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(model, entity);
            await _repo.UpdateAsync(entity);
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;

            await _repo.DeleteAsync(id);
            return true;
        }
    }
}
