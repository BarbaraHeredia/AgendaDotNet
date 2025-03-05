using APIAgenda.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIAgenda.Repositories
{
    public interface IEventActionRepository
    {
        Task<IEnumerable<EventAction>> GetEventActionsAsync();
        Task<EventAction> GetEventActionAsync(int id);
        Task<EventAction> CreateAsync(EventAction eventAction);
        Task<EventAction> UpdateAsync(EventAction eventAction);
        Task<EventAction> DeleteAsync(int id);
    }
}
