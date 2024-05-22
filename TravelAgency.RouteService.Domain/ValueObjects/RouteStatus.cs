namespace TravelAgency.RouteService.Domain.ValueObjects;
public sealed class RouteStatus : SmartEnum<RouteStatus>
{
    public static readonly RouteStatus Open = new RouteStatus(nameof(Open), 1);
    public static readonly RouteStatus OfferAccepted = new RouteStatus(nameof(OfferAccepted), 2);
    public static readonly RouteStatus Paid = new RouteStatus(nameof(Paid), 3);

    public RouteStatus(string name, int value) : base(name, value)
    {
    }
}
