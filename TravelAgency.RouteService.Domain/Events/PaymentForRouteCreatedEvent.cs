namespace TravelAgency.RouteService.Domain.Events;
public sealed class PaymentForRouteCreatedEvent : BaseEvent
{
    public int PaymentId { get; set; }
    public int RouteId { get; set; }
}
