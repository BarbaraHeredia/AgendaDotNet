using APIAgenda.Models;
using APIAgenda.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIAgenda.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEventsAsync(PaginationParameters paginationParameters);
        Task<Event> GetEventAsync(int id);
        Task<Event> CreateAsync(Event myEvent);
        Task<Event> UpdateAsync(Event myEvent);
        Task<Event> DeleteAsync(int id);
    }
}
