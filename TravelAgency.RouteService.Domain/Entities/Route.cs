

namespace TravelAgency.RouteService.Domain.Entities;
public sealed class Route : BaseAuditableEntity
{
    public required int ClientId { get; set; }
    public required RouteStatus Status { get; set; }

    public int? PaymentId { get; set; }
    public Payment? Payment { get; set; }

    public required ICollection<Passager> Passagers { get; set; }
    public required ICollection<RouteApplication> RouteApplications { get; set; }
}
