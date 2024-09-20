using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectManagement.Common;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPostgreSqlDbContext<TDbContext>(this IServiceCollection services,
        Action<DbContextOptionsBuilder> action) where TDbContext : DbContext
    {
        services.AddDbContext<TDbContext>(action);
        services.AddScoped<IUnitOfWork, UnitOfWork<TDbContext>>();
        return services;
    }
}