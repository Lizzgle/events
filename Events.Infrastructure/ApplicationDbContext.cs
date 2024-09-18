using Events.Domain.Entities;
using Events.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Event> Events => Set<Event>();

        public DbSet<Participant> Participants => Set<Participant>();
        public DbSet<User> Users => Set<User>();

        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventEntityTypeConfigurator());


            base.OnModelCreating(modelBuilder);
        }
    }
}
