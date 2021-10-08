﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Infrastructure.Persistence.Migrations
{
    using Common.Persistence;

    [DbContext(typeof(CarRentalDbContext))]
    [Migration("20200523125432_InitialDomainTables")]
    partial class InitialDomainTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarRentalSystem.Domain.Models.CarAds.CarAd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("DealerId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(2048)")
                        .HasMaxLength(2048);

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<decimal>("PricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DealerId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("CarAds");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Models.CarAds.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Models.CarAds.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Models.Dealers.Dealer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Dealers");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Models.CarAds.CarAd", b =>
                {
                    b.HasOne("CarRentalSystem.Domain.Models.CarAds.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarRentalSystem.Domain.Models.Dealers.Dealer", null)
                        .WithMany("CarAds")
                        .HasForeignKey("DealerId");

                    b.HasOne("CarRentalSystem.Domain.Models.CarAds.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("CarRentalSystem.Domain.Models.CarAds.Options", "Options", b1 =>
                        {
                            b1.Property<int>("CarAdId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<bool>("HasClimateControl")
                                .HasColumnType("bit");

                            b1.Property<int>("NumberOfSeats")
                                .HasColumnType("int");

                            b1.HasKey("CarAdId");

                            b1.ToTable("CarAds");

                            b1.WithOwner()
                                .HasForeignKey("CarAdId");

                            b1.OwnsOne("CarRentalSystem.Domain.Models.CarAds.TransmissionType", "TransmissionType", b2 =>
                                {
                                    b2.Property<int>("OptionsCarAdId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<int>("Value")
                                        .HasColumnType("int");

                                    b2.HasKey("OptionsCarAdId");

                                    b2.ToTable("CarAds");

                                    b2.WithOwner()
                                        .HasForeignKey("OptionsCarAdId");
                                });
                        });
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Models.Dealers.Dealer", b =>
                {
                    b.OwnsOne("CarRentalSystem.Domain.Models.Dealers.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<int>("DealerId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DealerId");

                            b1.ToTable("Dealers");

                            b1.WithOwner()
                                .HasForeignKey("DealerId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
