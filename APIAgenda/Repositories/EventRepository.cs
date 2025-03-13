using APIAgenda.Context;
using APIAgenda.Models;
using APIAgenda.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIAgenda.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            return await _context.Events
                .OrderBy(e => e.Id)
                .ToListAsync();
        }

        public async Task<Event> GetEventAsync(int id)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Event> CreateAsync(Event myEvent)
        {
            if (myEvent is null)
            {
                throw new ArgumentNullException(nameof(myEvent));
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == myEvent.UserId);
            if (user == null)
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }

            myEvent.User = user;

            _context.Events.Add(myEvent);
            return myEvent;
        }


        public async Task<Event> UpdateAsync(Event myEvent)
        {
            if (myEvent is null)
            {
                throw new ArgumentNullException(nameof(myEvent));
            }
            _context.Entry(myEvent).State = EntityState.Modified;
            return myEvent;
        }

        public async Task<Event> DeleteAsync(int id)
        {
            var myEvent = await _context.Events.FindAsync(id);
            if (myEvent is null)
            {
                throw new ArgumentNullException(nameof(myEvent));
            }
            _context.Events.Remove(myEvent);
            return myEvent;
        }

        public async Task<PagedList<Event>> GetEventsAsync(PaginationParameters paginationParameters)
        {
            var query = _context.Events
                .OrderBy(e => e.Id)
                .AsQueryable();

            return await PagedList<Event>.ToPagedList(query, paginationParameters.PageNumber, paginationParameters.PageSize);

        }
    }
}
