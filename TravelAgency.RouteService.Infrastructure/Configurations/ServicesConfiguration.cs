using Microsoft.Extensions.DependencyInjection;
using TravelAgency.RouteService.Application.Common.Interfaces;
using TravelAgency.RouteService.Infrastructure.Services;

namespace TravelAgency.RouteService.Infrastructure.Configurations;
public static class ServicesConfigurations
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IDateTimeService, DateTimeService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}
