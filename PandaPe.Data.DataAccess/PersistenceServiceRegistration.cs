using PandaPe.Data.Application.Contracts.Persistence.Repositories;
using PandaPe.Data.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PandaPe.Data.DataAccess
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PandaPeDbContext>(options => options.UseInMemoryDatabase(databaseName: "PandaPeDb"));

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            return services;
        }
    }
}
