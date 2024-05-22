using Microsoft.Extensions.DependencyInjection;
using TravelAgency.RouteService.Application.Common.Interfaces;
using TravelAgency.RouteService.Infrastructure.Interceptors;
using TravelAgency.RouteService.Infrastructure.Persistance;

namespace TravelAgency.RouteService.Infrastructure.Configurations;
public static class DatabaseConfiguration
{
    public static IServiceCollection RegisterDatabaseTools(this IServiceCollection services)
    {
        services.AddScoped<RouteServiceDbContextInitialiser>();
        services.AddScoped<IRouteServiceDbContext, RouteServiceDbContext>();
        services.AddScoped<BaseAuditableEntitySaveChangesInterceptor>();

        return services;
    }
}
