using APIAgenda.Context;
using APIAgenda.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIAgenda.Repositories
{
    public class EventEmailRepository : IEventEmailRepository
    {
        private readonly AppDbContext _context;

        public EventEmailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventEmail>> GetEventEmailsAsync()
        {
            return await _context.Emails.ToListAsync();
        }

        public async Task<EventEmail> GetEventEmailAsync(int id)
        {
            return await _context.Emails.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<EventEmail> CreateAsync(EventEmail eventEmail)
        {
            if (eventEmail is null)
            {
                throw new ArgumentNullException(nameof(eventEmail));
            }

            _context.Emails.Add(eventEmail);
            // O Commit será feito pela UnitOfWork
            return eventEmail;
        }

        public async Task<EventEmail> UpdateAsync(EventEmail eventEmail)
        {
            if (eventEmail is null)
            {
                throw new ArgumentNullException(nameof(eventEmail));
            }
            _context.Entry(eventEmail).State = EntityState.Modified;
            // O Commit será feito pela UnitOfWork
            return eventEmail;
        }

        public async Task<EventEmail> DeleteAsync(int id)
        {
            var eventEmail = await _context.Emails.FindAsync(id);
            if (eventEmail is null)
            {
                throw new ArgumentNullException(nameof(eventEmail));
            }
            _context.Emails.Remove(eventEmail);
            // O Commit será feito pela UnitOfWork
            return eventEmail;
        }
    }
}
