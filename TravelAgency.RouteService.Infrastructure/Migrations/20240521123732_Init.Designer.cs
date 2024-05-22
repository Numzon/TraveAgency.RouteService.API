﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TravelAgency.RouteService.Infrastructure.Persistance;

#nullable disable

namespace TravelAgency.RouteService.Infrastructure.Migrations
{
    [DbContext(typeof(RouteServiceDbContext))]
    [Migration("20240521123732_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TravelAgency.RouteService.Domain.Entities.Passager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Passager");
                });

            modelBuilder.Entity("TravelAgency.RouteService.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<int>("RouteApplicationId")
                        .HasColumnType("integer");

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TravelAgencyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RouteApplicationId")
                        .IsUnique();

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("TravelAgency.RouteService.Domain.Entities.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId")
                        .IsUnique();

                    b.ToTable("Route");
                });

            modelBuilder.Entity("TravelAgency.RouteService.Domain.Entities.RouteApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("integer");

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("TravelAgencyId")
                        .HasColumnType("integer");

                    b.Property<int>("VehicleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("RouteApplication");
                });

            modelBuilder.Entity("TravelAgency.RouteService.Domain.Entities.Passager", b =>
                {
                    b.HasOne("TravelAgency.RouteService.Domain.Entities.Route", "Route")
                        .WithMany("Passagers")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("TravelAgency.RouteService.Domain.Entities.Payment", b =>
                {
                    b.HasOne("TravelAgency.RouteService.Domain.Entities.RouteApplication", "RouteApplication")
                        .WithOne("Payment")
                        .HasForeignKey("TravelAgency.RouteService.Domain.Entities.Payment", "RouteApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RouteApplication");
                });

            modelBuilder.Entity("TravelAgency.RouteService.Domain.Entities.Route", b =>
                {
                    b.HasOne("TravelAgency.RouteService.Domain.Entities.Payment", "Payment")
                        .WithOne("Route")
                        .HasForeignKey("TravelAgency.RouteService.Domain.Entities.Route", "PaymentId");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("TravelAgency.RouteService.Domain.Entities.RouteApplication", b =>
                {
                    b.HasOne("TravelAgency.RouteService.Domain.Entities.Route", "Route")
                        .WithMany("RouteApplications")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("TravelAgency.RouteService.Domain.Entities.Payment", b =>
                {
                    b.Navigation("Route")
                        .IsRequired();
                });

            modelBuilder.Entity("TravelAgency.RouteService.Domain.Entities.Route", b =>
                {
                    b.Navigation("Passagers");

                    b.Navigation("RouteApplications");
                });

            modelBuilder.Entity("TravelAgency.RouteService.Domain.Entities.RouteApplication", b =>
                {
                    b.Navigation("Payment");
                });
#pragma warning restore 612, 618
        }
    }
}
