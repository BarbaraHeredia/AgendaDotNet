using APIAgenda.Context;
using APIAgenda.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIAgenda.Repositories
{
    public class EventReminderRepository : IEventReminderRepository
    {
        private readonly AppDbContext _context;

        public EventReminderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventReminder>> GetEventRemindersAsync()
        {
            return await _context.Reminders.ToListAsync();
        }

        public async Task<EventReminder> GetEventReminderAsync(int id)
        {
            return await _context.Reminders.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<EventReminder> CreateAsync(EventReminder eventReminder)
        {
            if (eventReminder is null)
            {
                throw new ArgumentNullException(nameof(eventReminder));
            }

            _context.Reminders.Add(eventReminder);
            // O Commit será feito pela UnitOfWork
            return eventReminder;
        }

        public async Task<EventReminder> UpdateAsync(EventReminder eventReminder)
        {
            if (eventReminder is null)
            {
                throw new ArgumentNullException(nameof(eventReminder));
            }
            _context.Entry(eventReminder).State = EntityState.Modified;
            // O Commit será feito pela UnitOfWork
            return eventReminder;
        }

        public async Task<EventReminder> DeleteAsync(int id)
        {
            var eventReminder = await _context.Reminders.FindAsync(id);
            if (eventReminder is null)
            {
                throw new ArgumentNullException(nameof(eventReminder));
            }
            _context.Reminders.Remove(eventReminder);
            // O Commit será feito pela UnitOfWork
            return eventReminder;
        }
    }
}
