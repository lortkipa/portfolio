using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Data.Entities;
using Portfolio.Data.Infastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Dal.Repositories
{
    public interface ISkillTagRepository : IBaseRepository<SkillTag>
    {
        Task<SkillTag> GetBySkillAndTagAsync(int skillId, int tagId);
    }
    public class SkillTagRepository : BaseRepository<SkillTag>, ISkillTagRepository
    {
        private readonly PortfolioContext _context;
        public SkillTagRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SkillTag> GetBySkillAndTagAsync(int skillId, int tagId)
        {
            return await _context.SkillTags
                .FirstOrDefaultAsync(s => s.SkillId == skillId && s.TagId == tagId);
        }
    }
}
