using Common.Repository;
using EduConnect.API.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using PRN232.Lab2.CoffeeStore.Repositories.Data;
using PRN232.Lab2.CoffeeStore.Repositories.Entities;
using PRN232.Lab2.CoffeeStore.Repositories.Interfaces;
using PRN232.Lab2.CoffeeStore.Repositories.Repositories;
using PRN232.Lab2.CoffeeStore.Services.Interfaces;
using PRN232.Lab2.CoffeeStore.Services.MapperProfile;
using PRN232.Lab2.CoffeeStore.Services.Services;

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

            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 1;

                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<CoffeeStoreDB2Context>()
            .AddDefaultTokenProviders();


            //Repository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            //Service
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();

            //Other
            services.AddJWTAuthenticationScheme(configuration);
            services.AddAutoMapper(cfg => { }, typeof(MappingProfile));



            return services;
        }
    }
}
