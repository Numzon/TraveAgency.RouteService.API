using TravelAgency.RouteService.Application.Common.Interfaces;

namespace TravelAgency.RouteService.Infrastructure.Services;
public sealed class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.UtcNow;
}
