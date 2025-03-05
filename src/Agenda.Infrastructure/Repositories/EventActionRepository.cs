using APIAgenda.Context;
using APIAgenda.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIAgenda.Repositories
{
    public class EventActionRepository : IEventActionRepository
    {
        private readonly AppDbContext _context;

        public EventActionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventAction>> GetEventActionsAsync()
        {
            return await _context.EventActions.ToListAsync();
        }

        public async Task<EventAction> GetEventActionAsync(int id)
        {
            return await _context.EventActions.FirstOrDefaultAsync(e => e.EventActionId == id);
        }

        public async Task<EventAction> CreateAsync(EventAction eventAction)
        {
            if (eventAction is null)
            {
                throw new ArgumentNullException(nameof(eventAction));
            }

            var myEvent = await _context.Events.FirstOrDefaultAsync(e => e.Id == eventAction.EventId);
            if(myEvent == null)
            {
                throw new InvalidOperationException("Id de evento não encontrado");
            }

            eventAction.Event = myEvent;

            _context.EventActions.Add(eventAction);
            
            return eventAction;
        }

        public async Task<EventAction> UpdateAsync(EventAction eventAction)
        {
            if (eventAction is null)
            {
                throw new ArgumentNullException(nameof(eventAction));
            }
            _context.Entry(eventAction).State = EntityState.Modified;
            return eventAction;
        }

        public async Task<EventAction> DeleteAsync(int id)
        {
            var eventAction = await _context.EventActions.FindAsync(id);
            if (eventAction is null)
            {
                throw new ArgumentNullException(nameof(eventAction));
            }
            _context.EventActions.Remove(eventAction);
            return eventAction;
        }
    }
}
