using Mapster;
using Microsoft.EntityFrameworkCore;
using TravelAgency.RouteService.Application.Common.Interfaces;
using TravelAgency.RouteService.Application.Routes.Commands.CreateRoute;
using TravelAgency.RouteService.Domain.Events;
using TravelAgency.RouteService.Domain.ValueObjects;

namespace TravelAgency.RouteService.Infrastructure.Repositories;
public sealed class RouteRepository : IRouteRepository
{
    private readonly IRouteServiceDbContext _context;

    public RouteRepository(IRouteServiceDbContext context)
    {
        _context = context;
    }

    public async Task<Route> CreateAsync(CreateRouteRequest request, CancellationToken cancellationToken)
    {
        var route = request.Adapt<Route>();
        route.Status = RouteStatus.Open;

        await _context.Route.AddAsync(route);
        await _context.SaveChangesAsync();

        return route;
    }

    public async Task UpdatePaymentIdAsync(PaymentForRouteCreatedEvent notification, CancellationToken cancellationToken)
    {
        var route = await _context.Route.FirstOrDefaultAsync(x => x.Id == notification.RouteId, cancellationToken);

        if (route == null)
        {
            Log.Error($"Route not found. Id: {notification.RouteId}");
            return;
        }

        route.PaymentId = notification.PaymentId;
        _context.Route.Entry(route);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
