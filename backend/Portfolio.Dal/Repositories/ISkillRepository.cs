using Portfolio.Data;
using Portfolio.Data.Entities;
using Portfolio.Data.Infastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Dal.Repositories
{
    public interface ISkillRepository : IBaseRepository<Skill>
    {
    }
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        private readonly PortfolioContext _context;
        public SkillRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }
    }
}