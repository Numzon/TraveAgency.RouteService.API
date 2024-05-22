using Microsoft.Extensions.DependencyInjection;
using TravelAgency.RouteService.Application.Common.Models;
using TravelAgency.RouteService.Application.Routes.Commands.CreateRoute;
using TravelAgency.RouteService.Domain.Entities;

namespace TravelAgency.RouteService.Application.Common.Configurations;
public static class MapsterConfiguration
{
    public static IServiceCollection RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig<Route, CreateRouteRequest>
            .NewConfig()
            .Map(dest => dest.Passagers, src => src.Passagers);

        TypeAdapterConfig<Payment, PaymentDto>
            .NewConfig()
            .Map(dest => dest.TransactionDate, src => src.Created);

        return services;
    }
}
