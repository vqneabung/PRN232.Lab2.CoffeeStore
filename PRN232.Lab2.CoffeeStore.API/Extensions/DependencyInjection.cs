using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PRN232.Lab2.CoffeeStore.Repositories.Data;

namespace PRN232.Lab2.CoffeeStore.API.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DATABASE_CONNECTION_STRING"];
            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Warning: DATABASE_CONNECTION_STRING is not set in environment variables.");
            }

            services.AddDbContext<CoffeeStoreDB2Context>(options =>
               options.UseSqlServer(connectionString)
                   .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning)));


            return services;
        }
    }
}
