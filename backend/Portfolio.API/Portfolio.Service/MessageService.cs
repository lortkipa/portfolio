using AutoMapper;
using Portfolio.Dal.Repositories;
using Portfolio.Data.Entities;
using Portfolio.Service.DTO.Contact;
using Portfolio.Service.DTO.Message;
using Portfolio.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repo;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageDTO>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<MessageDTO>>(entities);
        }
        public async Task<MessageDTO> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) throw new Exception("entity not found");

            return _mapper.Map<MessageDTO>(entity);
        }
        public async Task<MessageDTO> CreateAsync(CreateMessageDTO model)
        {
            if (model == null) return null;

            var entity = _mapper.Map<Message>(model);
            await _repo.AddAsync(entity);
            return _mapper.Map<MessageDTO>(entity);
        }
        public async Task<bool> UpdateAsync(int id, UpdateMessageDTO model)
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
