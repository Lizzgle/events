using Events.Domain.Entities;
using Events.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Participant> Participants => Set<Participant>();

        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();

        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventEntityTypeConfigurator());
            modelBuilder.ApplyConfiguration(new ParticipantEntityTypeConfigurator());
            modelBuilder.ApplyConfiguration(new RoleEntityTypeConfigurator());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfigurator());


            base.OnModelCreating(modelBuilder);
        }
    }
}
