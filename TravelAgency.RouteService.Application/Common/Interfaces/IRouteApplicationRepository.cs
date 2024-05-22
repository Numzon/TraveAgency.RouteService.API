using TravelAgency.RouteService.Application.RouteApplications.Commands;
using TravelAgency.RouteService.Domain.Entities;
using TravelAgency.RouteService.Domain.Events;

namespace TravelAgency.RouteService.Application.Common.Interfaces;
public interface IRouteApplicationRepository
{
    Task<RouteApplication> CreateAsync(CreateRouteApplicationRequest request, CancellationToken cancellationToken);
    Task UpdatePaymentIdAsync(PaymentForRouteApplicationCreatedEvent notification, CancellationToken cancellationToken);
}
