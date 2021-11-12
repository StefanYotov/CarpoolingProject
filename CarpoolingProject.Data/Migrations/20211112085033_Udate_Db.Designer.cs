﻿// <auto-generated />
using System;
using CarpoolingProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarpoolingProject.Data.Migrations
{
    [DbContext(typeof(CarpoolingContext))]
    [Migration("20211112085033_Udate_Db")]
    partial class Udate_Db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarpoolingProject.Data.Travel", b =>
                {
                    b.Property<int>("TravelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndPoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FreeSpots")
                        .HasColumnType("int");

                    b.Property<string>("StartPoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TravelId");

                    b.HasIndex("UserId");

                    b.ToTable("Travels");

                    b.HasData(
                        new
                        {
                            TravelId = 1,
                            DepartureTime = new DateTime(2021, 11, 15, 22, 50, 0, 0, DateTimeKind.Unspecified),
                            EndPoint = "Selo Sofia",
                            FreeSpots = 4,
                            StartPoint = "velcho atanasov 55",
                            UserId = 1
                        },
                        new
                        {
                            TravelId = 2,
                            DepartureTime = new DateTime(2021, 11, 15, 22, 50, 0, 0, DateTimeKind.Unspecified),
                            EndPoint = "Selo Sofia",
                            FreeSpots = 2,
                            StartPoint = "velcho atanasov 55",
                            UserId = 2
                        },
                        new
                        {
                            TravelId = 3,
                            DepartureTime = new DateTime(2021, 11, 15, 22, 50, 0, 0, DateTimeKind.Unspecified),
                            EndPoint = "Selo Sofia",
                            FreeSpots = 3,
                            StartPoint = "velcho atanasov 55",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("CarpoolingProject.Models.EntityModels.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.HasIndex("CityId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            CityId = 1,
                            StreetName = "ulica selo"
                        });
                });

            modelBuilder.Entity("CarpoolingProject.Models.EntityModels.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CountryId = 1,
                            Name = "Varna"
                        });
                });

            modelBuilder.Entity("CarpoolingProject.Models.EntityModels.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bulgaria"
                        });
                });

            modelBuilder.Entity("CarpoolingProject.Models.EntityModels.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            Name = "Driver"
                        },
                        new
                        {
                            RoleId = 3,
                            Name = "Passanger"
                        },
                        new
                        {
                            RoleId = 4,
                            Name = "Blocked"
                        });
                });

            modelBuilder.Entity("CarpoolingProject.Models.EntityModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int?>("TravelId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId");

                    b.HasIndex("TravelId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "pesho.salama@gmail.com",
                            FirstName = "Pesho",
                            LastName = "Salama",
                            Password = "bezparola",
                            PhoneNumber = 88865432,
                            UserName = "PeshoSalama"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "foncho.tarikata@gmail.com",
                            FirstName = "Foncho",
                            LastName = "Tarikata",
                            Password = "bezparola",
                            PhoneNumber = 88863432,
                            UserName = "Customer"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "lyubo.grigorov@gmail.com",
                            FirstName = "Lyubo",
                            LastName = "Grigorov",
                            Password = "bezparola",
                            PhoneNumber = 88845432,
                            UserName = "Shafior"
                        });
                });

            modelBuilder.Entity("CarpoolingProject.Models.EntityModels.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1,
                            Id = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2,
                            Id = 2
                        });
                });

            modelBuilder.Entity("CarpoolingProject.Data.Travel", b =>
                {
                    b.HasOne("CarpoolingProject.Models.EntityModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarpoolingProject.Models.EntityModels.Address", b =>
                {
                    b.HasOne("CarpoolingProject.Models.EntityModels.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CarpoolingProject.Models.EntityModels.City", b =>
                {
                    b.HasOne("CarpoolingProject.Models.EntityModels.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CarpoolingProject.Models.EntityModels.User", b =>
                {
                    b.HasOne("CarpoolingProject.Data.Travel", null)
                        .WithMany("Users")
                        .HasForeignKey("TravelId");
                });

            modelBuilder.Entity("CarpoolingProject.Models.EntityModels.UserRole", b =>
                {
                    b.HasOne("CarpoolingProject.Models.EntityModels.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CarpoolingProject.Models.EntityModels.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarpoolingProject.Data.Travel", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CarpoolingProject.Models.EntityModels.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("CarpoolingProject.Models.EntityModels.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CarpoolingProject.Models.EntityModels.User", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
