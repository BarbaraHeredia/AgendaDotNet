using APIAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAgenda.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Event>? Events { get; set; }
        public DbSet<EventAction>? EventActions { get; set; }
        public DbSet<EventEmail>? Emails { get; set; }
        public DbSet<EventMessage>? EventMessages { get; set; }
        public DbSet<EventReminder>? Reminders { get; set; }
        public DbSet<RecurringTask>? RecurringTasks { get; set; }

    }
}
