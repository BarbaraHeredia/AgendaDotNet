using APIAgenda.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIAgenda.Repositories
{
    public interface IEventReminderRepository
    {
        Task<IEnumerable<EventReminder>> GetEventRemindersAsync();
        Task<EventReminder> GetEventReminderAsync(int id);
        Task<EventReminder> CreateAsync(EventReminder eventReminder);
        Task<EventReminder> UpdateAsync(EventReminder eventReminder);
        Task<EventReminder> DeleteAsync(int id);
    }
}
