namespace TravelAgency.RouteService.Domain.ValueObjects;

public sealed class RouteApplicationStatus : SmartEnum<RouteApplicationStatus>
{
    public static readonly RouteApplicationStatus Applied = new RouteApplicationStatus(nameof(Applied), 1);

    public RouteApplicationStatus(string name, int value) : base(name, value)
    {
    }
}
