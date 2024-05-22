using TravelAgency.RouteService.Infrastructure.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TravelAgency.RouteService.Infrastructure.Extensions;
public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<RouteServiceDbContextInitialiser>();

        await initialiser.InitialiseAsync();
    }
}
