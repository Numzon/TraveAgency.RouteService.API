namespace TravelAgency.RouteService.Domain.Common;
public abstract class BaseLookupEntity : BaseAuditableEntity
{
    public required string Name { get; set; }
}
