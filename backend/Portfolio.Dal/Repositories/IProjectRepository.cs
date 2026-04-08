using Portfolio.Data;
using Portfolio.Data.Entities;
using Portfolio.Data.Infastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Dal.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
    }
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly PortfolioContext _context;
        public ProjectRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }
    }
}
