using APIAgenda.Context;
using APIAgenda.Models;
using APIAgenda.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIAgenda.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users
                        .OrderBy(u => u.UserName)
                        .ToListAsync();
        }

        public async Task<User?> GetUserAsync(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Event>> GetEventsByUserIdAsync(string userId, PaginationParameters paginationParameters)
        {
            //return await _context.Events.Where(e => e.UserId == userId).ToListAsync();

            return await _context.Events
               .Where(e => e.UserId == userId)
               .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
               .Take(paginationParameters.PageSize)
               .ToListAsync();
        }

        public async Task<User> CreateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await _context.Users.AddAsync(user);
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Entry(user).State = EntityState.Modified;
            return user;
        }

        public async Task<User> DeleteAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Remove(user);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(PaginationParameters paginationParameters)
        {
            return await _context.Users
                .OrderBy(u => u.UserName)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToListAsync();
        }
    }
}
