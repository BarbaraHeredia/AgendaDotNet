namespace APIAgenda.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IEventRepository EventRepository { get; }
        IEventActionRepository EventActionRepository { get; }
        IEventEmailRepository EventEmailRepository { get; }
        IEventReminderRepository EventReminderRepository { get; }
        IEventMessageRepository EventMessageRepository { get; }
        Task<int> CommitAsync();
    }
}
