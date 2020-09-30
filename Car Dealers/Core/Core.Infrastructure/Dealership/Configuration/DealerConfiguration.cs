namespace CarRentalSystem.Infrastructure.Dealership.Configuration
{
    using Domain.Dealerships.Models.Dealers;
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Domain.Common.Models.ModelConstants.Common;

    internal class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .OwnsOne(
                    d => d.PhoneNumber,
                    p =>
                    {
                        p.WithOwner();

                        p.Property(pn => pn.Number);
                    });

            builder
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Dealer>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(d => d.CarAds)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("carAds");
        }
    }
}
