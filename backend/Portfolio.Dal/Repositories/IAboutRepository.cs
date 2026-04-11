using Portfolio.Data;
using Portfolio.Data.Entities;
using Portfolio.Data.Infastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Dal.Repositories
{
    public interface IAboutRepository : IBaseRepository<About>
    {
    }
    public class AboutRepository : BaseRepository<About>, IAboutRepository
    {
        private readonly PortfolioContext _context;
        public AboutRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }
    }
}