using Microsoft.EntityFrameworkCore;
using TravelAgency.RouteService.Domain.Entities;

namespace TravelAgency.RouteService.Application.Common.Interfaces;
public interface IRouteServiceDbContext
{
    DbSet<Passager> Passager { get; set; }
    DbSet<Payment> Payment { get; set; }
    DbSet<Route> Route { get; set; }
    DbSet<RouteApplication> RouteApplication { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
