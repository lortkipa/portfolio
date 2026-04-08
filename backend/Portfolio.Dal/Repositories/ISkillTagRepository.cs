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
    }
    public class SkillTagRepository : BaseRepository<SkillTag>, ISkillTagRepository
    {
        private readonly PortfolioContext _context;
        public SkillTagRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }
    }
}
