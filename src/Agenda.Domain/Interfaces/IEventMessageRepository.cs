using Agenda.Domain.Models;

namespace APIAgenda.Repositories
{
    public interface IEventMessageRepository
    {
        Task<IEnumerable<EventMessage>> GetEventMessagesAsync();
        Task<EventMessage> GetEventMessageAsync(int id);
        Task<EventMessage> CreateAsync(EventMessage eventMessage);
        Task<EventMessage> UpdateAsync(EventMessage eventMessage);
        Task<EventMessage> DeleteAsync(int id);
    }
}
