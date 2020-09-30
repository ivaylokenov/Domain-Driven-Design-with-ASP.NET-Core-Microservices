namespace CarRentalSystem.Infrastructure.Statistics.Configuration
{
    using Domain.Statistics.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarAdViewConfiguration : IEntityTypeConfiguration<CarAdView>
    {
        public void Configure(EntityTypeBuilder<CarAdView> builder) 
            => builder.HasKey(cav => cav.Id);
    }
}
