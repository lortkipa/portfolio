using AutoMapper;
using Portfolio.Dal.Repositories;
using Portfolio.Data.Entities;
using Portfolio.Service.DTO.SkillTag;
using Portfolio.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service
{
    public class SkillTagService : ISkillTagService
    {
        private readonly ISkillTagRepository _repo;
        private readonly IMapper _mapper;

        public SkillTagService(ISkillTagRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkillTagDTO>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<SkillTagDTO>>(entities);
        }
        public async Task<SkillTagDTO> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) throw new Exception("entity not found");

            return _mapper.Map<SkillTagDTO>(entity);
        }
        public async Task<bool> CreateAsync(CreateSkillTagDTO model)
        {
            if (model == null) return false;

            var entity = _mapper.Map<SkillTag>(model);
            await _repo.AddAsync(entity);
            return _mapper.Map<SkillTagDTO>(entity) != null;
        }
        public async Task<bool> UpdateAsync(int id, UpdateSkillTagDTO model)
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
        public async Task<bool> AddTag(int skillId, int tagId)
        {
            var entity = new SkillTag
            {
                SkillId = skillId,
                TagId = tagId
            };

            await _repo.AddAsync(entity);
            return true;
        }
        public async Task<bool> RemoveTag(int skillId, int tagId)
        {
            var entity = await _repo.GetBySkillAndTagAsync(skillId, tagId);
            if (entity == null)
                return false;

            await _repo.DeleteAsync(entity.Id);
            return true;
        }
    }
}
