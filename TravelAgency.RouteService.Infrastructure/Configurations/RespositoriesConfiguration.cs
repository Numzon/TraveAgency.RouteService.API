using Microsoft.Extensions.DependencyInjection;
using TravelAgency.RouteService.Application.Common.Interfaces;
using TravelAgency.RouteService.Infrastructure.Repositories;

namespace TravelAgency.RouteService.Infrastructure.Configurations;
public static class RepositoriesConfiguration
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRouteRepository, RouteRepository>();
        services.AddScoped<IRouteApplicationRepository, RouteApplicationRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();

        return services;
    }
}
