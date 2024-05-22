using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TravelAgency.RouteService.Infrastructure.EntityConfigurations;
public sealed class RouteApplicationConfiguration : IEntityTypeConfiguration<RouteApplication>
{
    public void Configure(EntityTypeBuilder<RouteApplication> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.Cost)
            .IsRequired();

        builder.Property(x => x.VehicleId)
            .IsRequired();

        builder.Property(x => x.DriverId)
            .IsRequired();

        builder.Property(x => x.TravelAgencyId)
            .IsRequired();

        builder.HasOne(x => x.Route)
            .WithMany(x => x.RouteApplications)
            .HasForeignKey(x => x.RouteId)
            .IsRequired();

        builder.HasOne(x => x.Payment)
            .WithOne(x => x.RouteApplication)
            .HasForeignKey<Payment>(x => x.RouteApplicationId);
    }
}
