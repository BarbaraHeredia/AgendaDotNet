using APIAgenda.Context;
using APIAgenda.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIAgenda.Repositories
{
    public class EventMessageRepository : IEventMessageRepository
    {
        private readonly AppDbContext _context;

        public EventMessageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventMessage>> GetEventMessagesAsync()
        {
            return await _context.EventMessages.ToListAsync();
        }

        public async Task<EventMessage> GetEventMessageAsync(int id)
        {
            return await _context.EventMessages.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<EventMessage> CreateAsync(EventMessage eventMessage)
        {
            if (eventMessage is null)
            {
                throw new ArgumentNullException(nameof(eventMessage));
            }

            _context.EventMessages.Add(eventMessage);
            // O Commit será feito pela UnitOfWork
            return eventMessage;
        }

        public async Task<EventMessage> UpdateAsync(EventMessage eventMessage)
        {
            if (eventMessage is null)
            {
                throw new ArgumentNullException(nameof(eventMessage));
            }
            _context.Entry(eventMessage).State = EntityState.Modified;
            // O Commit será feito pela UnitOfWork
            return eventMessage;
        }

        public async Task<EventMessage> DeleteAsync(int id)
        {
            var eventMessage = await _context.EventMessages.FindAsync(id);
            if (eventMessage is null)
            {
                throw new ArgumentNullException(nameof(eventMessage));
            }
            _context.EventMessages.Remove(eventMessage);
            // O Commit será feito pela UnitOfWork
            return eventMessage;
        }
    }
}
