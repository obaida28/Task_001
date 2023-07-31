﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ObaidaAl_NaheelTask_001.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CarNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DailyRate")
                        .HasColumnType("int");

                    b.Property<decimal>("EngineCapacity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ef0bfe54-04da-43bf-864e-64f8b0ed8076"),
                            CustomerName = "Customer1"
                        },
                        new
                        {
                            Id = new Guid("d0d15006-36c4-4a6f-90ad-52b8a7e71497"),
                            CustomerName = "Customer2"
                        },
                        new
                        {
                            Id = new Guid("843cb4d9-45ff-432b-96b0-f8b27ae0b61a"),
                            CustomerName = "Customer3"
                        });
                });

            modelBuilder.Entity("Models.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DriverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<Guid?>("SubstitDriverId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubstitDriverId")
                        .IsUnique()
                        .HasFilter("[SubstitDriverId] IS NOT NULL");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("58f3e5ec-7b13-4be7-b020-774f8ef4832e"),
                            DriverName = "driver1",
                            IsAvailable = false
                        },
                        new
                        {
                            Id = new Guid("3f3e9c77-1d66-4c0b-bf1a-ab1591ab4140"),
                            DriverName = "driver2",
                            IsAvailable = false
                        },
                        new
                        {
                            Id = new Guid("f9213a9d-4a86-4db9-9857-94cd868fc7a5"),
                            DriverName = "driver3",
                            IsAvailable = false
                        });
                });

            modelBuilder.Entity("Models.Rental", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DriverId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DriverId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("Models.Driver", b =>
                {
                    b.HasOne("Models.Driver", "Substitute")
                        .WithOne()
                        .HasForeignKey("Models.Driver", "SubstitDriverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Substitute");
                });

            modelBuilder.Entity("Models.Rental", b =>
                {
                    b.HasOne("Models.Car", "Car")
                        .WithMany("Rentals")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Customer", "Customer")
                        .WithMany("Rentals")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Driver", "Driver")
                        .WithMany("Rentals")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Models.Car", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("Models.Driver", b =>
                {
                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
