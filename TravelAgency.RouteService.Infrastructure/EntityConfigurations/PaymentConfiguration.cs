using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TravelAgency.RouteService.Infrastructure.EntityConfigurations;
public sealed class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.Cost)
            .IsRequired();

        builder.HasOne(x => x.RouteApplication)
            .WithOne(x => x.Payment)
            .HasForeignKey<Payment>(x => x.RouteApplicationId)
            .IsRequired();
    }
}
