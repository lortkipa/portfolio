using Portfolio.Data;
using Portfolio.Data.Entities;
using Portfolio.Data.Infastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Dal.Repositories
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
    }
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        private readonly PortfolioContext _context;
        public ContactRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }
    }
}
