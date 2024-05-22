using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TravelAgency.RouteService.Infrastructure.EntityConfigurations;
public sealed class PassagerConfiguration : IEntityTypeConfiguration<Passager>
{
    public void Configure(EntityTypeBuilder<Passager> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .IsRequired();

        builder.Property(x => x.LastName)
            .IsRequired();

        builder.Property(x => x.Phone);

        builder.HasOne(x => x.Route)
            .WithMany(x => x.Passagers)
            .HasForeignKey(x => x.RouteId)
            .IsRequired();
    }
}
