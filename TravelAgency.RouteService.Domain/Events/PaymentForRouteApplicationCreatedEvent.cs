namespace TravelAgency.RouteService.Domain.Events;
public sealed class PaymentForRouteApplicationCreatedEvent : BaseEvent
{
    public int PaymentId { get; set; }
    public int RouteApplicationId { get; set; }
}
