namespace CarRentalSystem.Infrastructure.Dealership.Configuration
{
    using Domain.Dealerships.Models.CarAds;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Domain.Common.Models.ModelConstants.Common;
    using static Domain.Dealerships.Models.ModelConstants.Category;

    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);
        }
    }
}
