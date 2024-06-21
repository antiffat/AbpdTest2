﻿// <auto-generated />
using System;
using Abpd_Test2.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Abpd_Test2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Abpd_Test2.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarManufacturerId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarManufacturerId = 1,
                            ModelName = "SF21",
                            Number = 5,
                            RowVersion = new byte[0]
                        },
                        new
                        {
                            Id = 2,
                            CarManufacturerId = 1,
                            ModelName = "SF21",
                            Number = 16,
                            RowVersion = new byte[0]
                        },
                        new
                        {
                            Id = 3,
                            CarManufacturerId = 2,
                            ModelName = "W12",
                            Number = 44,
                            RowVersion = new byte[0]
                        });
                });

            modelBuilder.Entity("Abpd_Test2.Models.CarManufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CarManufacturers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ferrari",
                            RowVersion = new byte[0]
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mercedes",
                            RowVersion = new byte[0]
                        },
                        new
                        {
                            Id = 3,
                            Name = "Red Bull Racing",
                            RowVersion = new byte[0]
                        });
                });

            modelBuilder.Entity("Abpd_Test2.Models.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Competitions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Monaco Grand Prix",
                            RowVersion = new byte[0]
                        },
                        new
                        {
                            Id = 2,
                            Name = "British Grand Prix",
                            RowVersion = new byte[0]
                        },
                        new
                        {
                            Id = 3,
                            Name = "Italian Grand Prix",
                            RowVersion = new byte[0]
                        });
                });

            modelBuilder.Entity("Abpd_Test2.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(1997, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarId = 2,
                            FirstName = "Charles",
                            LastName = "Leclerc",
                            RowVersion = new byte[0]
                        },
                        new
                        {
                            Id = 2,
                            Birthday = new DateTime(1994, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarId = 1,
                            FirstName = "Carlos",
                            LastName = "Sainz",
                            RowVersion = new byte[0]
                        },
                        new
                        {
                            Id = 3,
                            Birthday = new DateTime(1985, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarId = 3,
                            FirstName = "Lewis",
                            LastName = "Hamilton",
                            RowVersion = new byte[0]
                        });
                });

            modelBuilder.Entity("Abpd_Test2.Models.DriverCompetition", b =>
                {
                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("DriverId", "CompetitionId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("DriverCompetitions");

                    b.HasData(
                        new
                        {
                            DriverId = 1,
                            CompetitionId = 1,
                            Date = new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RowVersion = new byte[0]
                        },
                        new
                        {
                            DriverId = 2,
                            CompetitionId = 1,
                            Date = new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RowVersion = new byte[0]
                        },
                        new
                        {
                            DriverId = 3,
                            CompetitionId = 1,
                            Date = new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RowVersion = new byte[0]
                        });
                });

            modelBuilder.Entity("Abpd_Test2.Models.Car", b =>
                {
                    b.HasOne("Abpd_Test2.Models.CarManufacturer", "CarManufacturer")
                        .WithMany("Cars")
                        .HasForeignKey("CarManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarManufacturer");
                });

            modelBuilder.Entity("Abpd_Test2.Models.Driver", b =>
                {
                    b.HasOne("Abpd_Test2.Models.Car", "Car")
                        .WithMany("Drivers")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Abpd_Test2.Models.DriverCompetition", b =>
                {
                    b.HasOne("Abpd_Test2.Models.Competition", "Competition")
                        .WithMany("DriverCompetitions")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abpd_Test2.Models.Driver", "Driver")
                        .WithMany("DriverCompetitions")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Abpd_Test2.Models.Car", b =>
                {
                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("Abpd_Test2.Models.CarManufacturer", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Abpd_Test2.Models.Competition", b =>
                {
                    b.Navigation("DriverCompetitions");
                });

            modelBuilder.Entity("Abpd_Test2.Models.Driver", b =>
                {
                    b.Navigation("DriverCompetitions");
                });
#pragma warning restore 612, 618
        }
    }
}
