using TravelAgency.RouteService.Application.Common.Interfaces;
using TravelAgency.RouteService.Domain.Events;

namespace TravelAgency.RouteService.Application.Routes.EventHandlers;
public sealed class PaymentForRouteCreatedEventHandler : INotificationHandler<PaymentForRouteCreatedEvent>
{
    private readonly IRouteRepository _routeRepository;

    public PaymentForRouteCreatedEventHandler(IRouteRepository routeRepository)
    {
        _routeRepository = routeRepository;
    }

    public async Task Handle(PaymentForRouteCreatedEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            await _routeRepository.UpdatePaymentIdAsync(notification, cancellationToken);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }
    }
}
