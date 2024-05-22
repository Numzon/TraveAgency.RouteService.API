namespace TravelAgency.RouteService.Domain.Entities;
public sealed class Passager : BaseAuditableEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Phone { get; set; }

    public required int RouteId { get; set; }
    public required Route Route { get; set; }
}
