using TravelAgency.RouteService.Application.Routes.Commands.CreateRoute;
using TravelAgency.RouteService.Domain.Entities;
using TravelAgency.RouteService.Domain.Events;

namespace TravelAgency.RouteService.Application.Common.Interfaces;
public interface IRouteRepository
{
    Task<Route> CreateAsync(CreateRouteRequest request, CancellationToken cancellationToken);
    Task UpdatePaymentIdAsync(PaymentForRouteCreatedEvent notification, CancellationToken cancellationToken);   
}
