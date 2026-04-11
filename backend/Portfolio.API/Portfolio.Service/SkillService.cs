using AutoMapper;
using Portfolio.Dal.Repositories;
using Portfolio.Data.Entities;
using Portfolio.Service.DTO.Skill;
using Portfolio.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _repo;
        private readonly IMapper _mapper;

        public SkillService(ISkillRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkillDTO>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<SkillDTO>>(entities);
        }
        public async Task<SkillDTO> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) throw new Exception("entity not found");

            return _mapper.Map<SkillDTO>(entity);
        }
        public async Task<SkillDTO> CreateAsync(CreateSkillDTO model)
        {
            if (model == null) return null;

            var entity = _mapper.Map<Skill>(model);
            await _repo.AddAsync(entity);
            return _mapper.Map<SkillDTO>(entity);
        }
        public async Task<bool> UpdateAsync(int id, UpdateSkillDTO model)
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
