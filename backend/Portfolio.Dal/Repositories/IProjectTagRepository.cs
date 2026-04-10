using Microsoft.EntityFrameworkCore;
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
        Task<ProjectTag> GetByProjectAndTagAsync(int projectId, int tagId);
    }
    public class ProjectTagRepository : BaseRepository<ProjectTag>, IProjectTagRepository
    {
        private readonly PortfolioContext _context;
        public ProjectTagRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProjectTag> GetByProjectAndTagAsync(int projectId, int tagId)
        {
            return await _context.ProjectTags
                .FirstOrDefaultAsync(pt => pt.ProjectId == projectId && pt.TagId == tagId);
        }
    }
}
