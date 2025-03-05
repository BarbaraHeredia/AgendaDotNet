using Agenda.Domain.Models;

namespace APIAgenda.Repositories
{
    public interface IEventEmailRepository
    {
        Task<IEnumerable<EventEmail>> GetEventEmailsAsync();
        Task<EventEmail> GetEventEmailAsync(int id);
        Task<EventEmail> CreateAsync(EventEmail eventEmail);
        Task<EventEmail> UpdateAsync(EventEmail eventEmail);
        Task<EventEmail> DeleteAsync(int id);
    }
}

