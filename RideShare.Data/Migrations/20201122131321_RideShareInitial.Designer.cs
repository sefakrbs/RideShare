﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RideShare.Data.Context;

namespace RideShare.Data.Migrations
{
    [DbContext(typeof(RideShareContext))]
    [Migration("20201122131321_RideShareInitial")]
    partial class RideShareInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RideShare.Data.Models.City", b =>
                {
                    b.Property<int>("CityCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityCode");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("RideShare.Data.Models.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("RideShare.Data.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Explanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TripDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("RideShare.Data.Models.Trip_City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Trip_Cities");
                });

            modelBuilder.Entity("RideShare.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RideShare.Data.Models.Passenger", b =>
                {
                    b.HasOne("RideShare.Data.Models.Trip", null)
                        .WithMany("Passengers")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RideShare.Data.Models.Trip", b =>
                {
                    b.HasOne("RideShare.Data.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("RideShare.Data.Models.Trip_City", b =>
                {
                    b.HasOne("RideShare.Data.Models.Trip", null)
                        .WithMany("RouteList")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RideShare.Data.Models.Trip", b =>
                {
                    b.Navigation("Passengers");

                    b.Navigation("RouteList");
                });
#pragma warning restore 612, 618
        }
    }
}