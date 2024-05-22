namespace TravelAgency.RouteService.Domain.Entities;
public sealed class Payment : BaseAuditableEntity
{
    public required decimal Cost { get; set; }
    public required PaymentStatus Status { get; set; }

    public required int RouteApplicationId { get; set; }
    public required RouteApplication RouteApplication { get; set; }

    public required int RouteId { get; set; }
    public required Route Route { get; set; }
}
