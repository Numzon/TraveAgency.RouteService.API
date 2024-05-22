using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TravelAgency.RouteService.Application.Common.Behaviour;
using TravelAgency.RouteService.Application.Common.Configurations;

namespace TravelAgency.RouteService.Application;
public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.RegisterMapsterConfiguration();
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });

        return services;
    }
}
