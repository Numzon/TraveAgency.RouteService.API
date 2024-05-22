namespace TravelAgency.RouteService.Domain.Entities;
public sealed class RouteApplication : BaseAuditableEntity
{
    public required RouteApplicationStatus Status { get; set; }
    public required decimal Cost { get; set; }
    public required int VehicleId { get; set; }
    public required int DriverId { get; set; }
    public required int TravelAgencyId { get; set; }

    public required int RouteId { get; set; }
    public required Route Route { get; set; }

    public int? PaymentId { get; set; }
    public Payment? Payment { get; set; }
}
