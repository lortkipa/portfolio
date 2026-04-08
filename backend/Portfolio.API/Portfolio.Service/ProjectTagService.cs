using AutoMapper;
using Portfolio.Dal.Repositories;
using Portfolio.Data.Entities;
using Portfolio.Service.DTO.Project;
using Portfolio.Service.DTO.ProjectTag;
using Portfolio.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service
{
    public class ProjectTagService : IProjectTagService
    {
        private readonly IProjectTagRepository _repo;
        private readonly IMapper _mapper;

        public ProjectTagService(IProjectTagRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectTagDTO>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ProjectTagDTO>>(entities);
        }
        public async Task<ProjectTagDTO> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) throw new Exception("entity not found");

            return _mapper.Map<ProjectTagDTO>(entity);
        }
        public async Task<bool> CreateAsync(CreateProjectTagDTO model)
        {
            if (model == null) return false;

            var entity = _mapper.Map<ProjectTag>(model);
            await _repo.AddAsync(entity);
            return _mapper.Map<ProjectTagDTO>(entity) != null;
        }
        public async Task<bool> UpdateAsync(int id, UpdateProjectTagDTO model)
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
