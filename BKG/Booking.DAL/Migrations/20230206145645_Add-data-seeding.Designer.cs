﻿// <auto-generated />
using System;
using Booking.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Booking.DAL.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20230206145645_Add-data-seeding")]
    partial class Adddataseeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Booking.DAL.Entities.BookingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookingFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BookingTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0c3db3ee-6f77-4b64-a5ec-27298749f421"),
                            BookingFrom = new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7897),
                            BookingTo = new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7898),
                            Description = "Nvm",
                            HotelId = new Guid("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"),
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("819f9de9-10d3-4459-a950-1561a34f0b9d"),
                            BookingFrom = new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7903),
                            BookingTo = new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7903),
                            Description = "Nvm2",
                            HotelId = new Guid("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"),
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("aae87a10-736e-47c0-9dba-b8550f902d0c"),
                            BookingFrom = new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7905),
                            BookingTo = new DateTime(2023, 2, 6, 14, 56, 45, 540, DateTimeKind.Utc).AddTicks(7906),
                            Description = "Idk",
                            HotelId = new Guid("60e6d76a-9c13-488b-afce-a3b21dbc3177"),
                            Price = 0m
                        });
                });

            modelBuilder.Entity("Booking.DAL.Entities.HotelEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CountRooms")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Address")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d990989f-bd61-450d-a6e9-b8eed2fd5ba2"),
                            Address = "Nvm",
                            CountRooms = 125,
                            CreatedTime = new DateTime(2023, 2, 6, 14, 56, 45, 541, DateTimeKind.Utc).AddTicks(1342),
                            Description = "Nvm",
                            Owner = "Dima Hatetovski",
                            PhoneNumber = "+375336869225",
                            Stars = 5,
                            Title = "GYM HOTEL"
                        },
                        new
                        {
                            Id = new Guid("60e6d76a-9c13-488b-afce-a3b21dbc3177"),
                            Address = "Idk",
                            CountRooms = 233,
                            CreatedTime = new DateTime(2023, 2, 6, 14, 56, 45, 541, DateTimeKind.Utc).AddTicks(1346),
                            Description = "Idk",
                            Owner = "Pashok Gagarin",
                            PhoneNumber = "+123456802232",
                            Stars = 3,
                            Title = "Pashok Hotel"
                        });
                });

            modelBuilder.Entity("Booking.DAL.Entities.BookingEntity", b =>
                {
                    b.HasOne("Booking.DAL.Entities.HotelEntity", "Hotel")
                        .WithMany("Bookings")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Booking.DAL.Entities.HotelEntity", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
