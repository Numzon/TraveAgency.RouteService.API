using Microsoft.EntityFrameworkCore;

namespace TravelAgency.RouteService.Infrastructure.Persistance;
public sealed class RouteServiceDbContextInitialiser
{
    private readonly RouteServiceDbContext _fleetServiceDbContext;

    public RouteServiceDbContextInitialiser(RouteServiceDbContext fleetServiceDbContext)
    {
        _fleetServiceDbContext = fleetServiceDbContext;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_fleetServiceDbContext.Database.IsNpgsql())
            {
                await _fleetServiceDbContext.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            Log.Error("An error occurred while initialising the database.", ex);
            throw;
        }
    }
}
