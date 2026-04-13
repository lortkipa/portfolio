using Portfolio.Data;
using Portfolio.Data.Entities;
using Portfolio.Data.Infastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Dal.Repositories
{
    public interface IEmailJSRepository : IBaseRepository<EmailJS>
    {
    }
    public class EmailJSRepository : BaseRepository<EmailJS>, IEmailJSRepository
    {
        private readonly PortfolioContext _context;
        public EmailJSRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }
    }
}
