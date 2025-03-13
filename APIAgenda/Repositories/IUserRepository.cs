using APIAgenda.Models;
using APIAgenda.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIAgenda.Repositories
{
    public interface IUserRepository
    {
        Task<PagedList<User>> GetUsersAsync(PaginationParameters paginationParameters);
        Task<PagedList<Event>> GetEventsByUserIdAsync(string userId, PaginationParameters paginationParameters);
        Task<User?> GetUserAsync(string id);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> DeleteAsync(string id);
    }
}
