using Portfolio.Data;
using Portfolio.Data.Entities;
using Portfolio.Data.Infastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Dal.Repositories
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
    }
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        private readonly PortfolioContext _context;
        public MessageRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }
    }
}
