using GerenciaServidoresAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciaServidoresAPI.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string dbProvider)
    {
        if (dbProvider == "sqlite")
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=servidores.db"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("ServidoresDb"));
        }

        return services;
    }
}
