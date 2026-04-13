using AutoMapper;
using Portfolio.Dal.Repositories;
using Portfolio.Data.Entities;
using Portfolio.Service.DTO.EmailJS;
using Portfolio.Service.DTO.Tag;
using Portfolio.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service
{
    public class EmailJSService : IEmailJSService
    {
        private readonly IEmailJSRepository _repo;
        private readonly IMapper _mapper;

        public EmailJSService(IEmailJSRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmailJSDTO>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<EmailJSDTO>>(entities);
        }
        public async Task<EmailJSDTO> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) throw new Exception("entity not found");

            return _mapper.Map<EmailJSDTO>(entity);
        }
        public async Task<EmailJSDTO> CreateAsync(CreateEmailJSDTO model)
        {
            if (model == null) return null;

            var entity = _mapper.Map<EmailJS>(model);
            await _repo.AddAsync(entity);
            return _mapper.Map<EmailJSDTO>(entity);
        }
        public async Task<bool> UpdateAsync(int id, UpdateEmailJSDTO model)
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
