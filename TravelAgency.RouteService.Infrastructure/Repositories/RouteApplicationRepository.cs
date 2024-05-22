using Mapster;
using Microsoft.EntityFrameworkCore;
using TravelAgency.RouteService.Application.Common.Interfaces;
using TravelAgency.RouteService.Application.RouteApplications.Commands;
using TravelAgency.RouteService.Domain.Events;
using TravelAgency.RouteService.Domain.ValueObjects;

namespace TravelAgency.RouteService.Infrastructure.Repositories;
public sealed class RouteApplicationRepository : IRouteApplicationRepository
{
    private readonly IRouteServiceDbContext _context;

    public RouteApplicationRepository(IRouteServiceDbContext context)
    {
        _context = context;
    }

    public async Task<RouteApplication> CreateAsync(CreateRouteApplicationRequest request, CancellationToken cancellationToken)
    {
        var routeApplication = request.Adapt<RouteApplication>();
        routeApplication.Status = RouteApplicationStatus.Applied;

        await _context.RouteApplication.AddAsync(routeApplication);
        await _context.SaveChangesAsync();

        return routeApplication;
    }

    public async Task UpdatePaymentIdAsync(PaymentForRouteApplicationCreatedEvent notification, CancellationToken cancellationToken)
    {
        var routeApplication = await _context.RouteApplication.FirstOrDefaultAsync(x => x.Id == notification.RouteApplicationId, cancellationToken);

        if (routeApplication == null)
        {
            Log.Error($"Route application not found. Id: {notification.RouteApplicationId}");
            return;
        }

        routeApplication.PaymentId = notification.PaymentId;
        _context.RouteApplication.Entry(routeApplication);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
