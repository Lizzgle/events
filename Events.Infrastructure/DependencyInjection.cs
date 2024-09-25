using Events.Domain.Abstractions;
using Events.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")
                                                        ?? throw new ArgumentNullException("Не найдена строка подключения к базе данных");

            services.AddDbContext<ApplicationDbContext>(cfg => cfg.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
