using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Data.Entities;
using Portfolio.Data.Infastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Dal.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly PortfolioContext _context;
        public UserRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
        .Include(u => u.Contact)                     // include related contact
        .FirstOrDefaultAsync(u => u.Contact!.Email == email);
        }
    }

}