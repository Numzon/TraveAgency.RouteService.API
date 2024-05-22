using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartEnum.EFCore;
using System.Reflection;
using TravelAgency.RouteService.Application.Common.Interfaces;
using TravelAgency.RouteService.Infrastructure.Extensions;
using TravelAgency.RouteService.Infrastructure.Interceptors;

namespace TravelAgency.RouteService.Infrastructure.Persistance;
public class RouteServiceDbContext : DbContext, IRouteServiceDbContext
{
    private readonly IMediator _mediator;
    private readonly BaseAuditableEntitySaveChangesInterceptor _baseAuditableEntitySaveChangesInterceptor;

    public DbSet<Passager> Passager { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<Route> Route { get; set; }
    public DbSet<RouteApplication> RouteApplication { get; set; }

    public RouteServiceDbContext(DbContextOptions<RouteServiceDbContext> options,
        IMediator mediator,
        BaseAuditableEntitySaveChangesInterceptor baseAuditableEntitySaveChangesInterceptor) : base(options)
    {
        _mediator = mediator;
        _baseAuditableEntitySaveChangesInterceptor = baseAuditableEntitySaveChangesInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureSmartEnum();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_baseAuditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}
