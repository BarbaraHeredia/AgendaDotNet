using APIAgenda.Context;
using System.Threading.Tasks;

namespace APIAgenda.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;
        private IEventRepository _eventRepository;
        private IEventActionRepository _eventActionRepository;
        private IEventEmailRepository _eventEmailRepository;
        private IEventReminderRepository _eventReminderRepository;
        private IEventMessageRepository _eventMessageRepository;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ??= new UserRepository(_context); }
        }

        public IEventRepository EventRepository
        {
            get { return _eventRepository ??= new EventRepository(_context); }
        }

        public IEventActionRepository EventActionRepository
        {
            get { return _eventActionRepository ??= new EventActionRepository(_context); }
        }

        public IEventEmailRepository EventEmailRepository
        {
            get { return _eventEmailRepository ??= new EventEmailRepository(_context); }
        }

        public IEventReminderRepository EventReminderRepository
        {
            get { return _eventReminderRepository ??= new EventReminderRepository(_context); }
        }

        public IEventMessageRepository EventMessageRepository
        {
            get { return _eventMessageRepository ??= new EventMessageRepository(_context); }
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
