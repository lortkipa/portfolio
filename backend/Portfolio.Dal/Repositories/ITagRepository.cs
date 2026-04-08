using Portfolio.Data;
using Portfolio.Data.Entities;
using Portfolio.Data.Infastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Dal.Repositories
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
    }
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        private readonly PortfolioContext _context;
        public TagRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }
    }
}
