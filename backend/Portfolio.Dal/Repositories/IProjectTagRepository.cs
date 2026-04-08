using Portfolio.Data;
using Portfolio.Data.Entities;
using Portfolio.Data.Infastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Dal.Repositories
{
    public interface IProjectTagRepository : IBaseRepository<ProjectTag>
    {
    }
    public class ProjectTagRepository : BaseRepository<ProjectTag>, IProjectTagRepository
    {
        private readonly PortfolioContext _context;
        public ProjectTagRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }
    }
}
