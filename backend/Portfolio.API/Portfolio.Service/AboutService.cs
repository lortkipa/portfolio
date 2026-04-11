using AutoMapper;
using Portfolio.Dal.Repositories;
using Portfolio.Data.Entities;
using Portfolio.Service.DTO.About;
using Portfolio.Service.DTO.Tag;
using Portfolio.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _repo;
        private readonly IMapper _mapper;

        public AboutService(IAboutRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AboutDTO>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<AboutDTO>>(entities);
        }
        public async Task<AboutDTO> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) throw new Exception("entity not found");

            return _mapper.Map<AboutDTO>(entity);
        }
        public async Task<AboutDTO> CreateAsync(CreateAboutDTO model)
        {
            if (model == null) return null;

            var entity = _mapper.Map<About>(model);
            await _repo.AddAsync(entity);
            return _mapper.Map<AboutDTO>(entity);
        }
        public async Task<bool> UpdateAsync(int id, UpdateAboutDTO model)
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
