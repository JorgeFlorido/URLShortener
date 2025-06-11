using Microsoft.EntityFrameworkCore;
using URLShortener.Application.Interfaces;
using URLShortener.Application.Services;
using URLShortener.Database;
using URLShortener.Database.Repositories;
using URLShortener.Domain.Abstractions;

namespace URLShortener.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UrlShortenerDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUrlRepository, UrlRepository>();
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUrlShortenerService, UrlShortenerService>();
            return services;
        }
    }
}
