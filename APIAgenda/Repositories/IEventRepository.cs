using APIAgenda.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIAgenda.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEventsAsync();
        Task<Event> GetEventAsync(int id);
        Task<Event> CreateAsync(Event myEvent);
        Task<Event> UpdateAsync(Event myEvent);
        Task<Event> DeleteAsync(int id);
    }
}
