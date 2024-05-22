using TravelAgency.RouteService.Application.Common.Interfaces;
using TravelAgency.RouteService.Domain.Events;

namespace TravelAgency.RouteService.Application.RouteApplications.EventHandlers;
public sealed class PaymentForRouteApplicationCreatedEventHandler : INotificationHandler<PaymentForRouteApplicationCreatedEvent>
{
    private readonly IRouteApplicationRepository _routeApplicationRepository;

    public PaymentForRouteApplicationCreatedEventHandler(IRouteApplicationRepository routeApplicationRepository)
    {
        _routeApplicationRepository = routeApplicationRepository;
    }

    public async Task Handle(PaymentForRouteApplicationCreatedEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            await _routeApplicationRepository.UpdatePaymentIdAsync(notification, cancellationToken);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }
    }
}
