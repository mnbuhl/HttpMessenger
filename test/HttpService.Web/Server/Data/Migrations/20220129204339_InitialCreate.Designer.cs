﻿// <auto-generated />
using System;
using HttpService.Web.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HttpService.Web.Server.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220129204339_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("HttpService.Web.Server.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(254);

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<long>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(255);

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b1558378-790b-48fa-8085-5f351836104f"),
                            CreatedAt = new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8396),
                            Description = "Best resource for learning C#",
                            Name = "C# Book",
                            Price = 15000L,
                            UpdatedAt = new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8424)
                        },
                        new
                        {
                            Id = new Guid("778a9780-ef52-4fc8-b136-13258afed44e"),
                            CreatedAt = new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8467),
                            Description = "Best resource for learning ASP.NET Core",
                            Name = "ASP.NET Core Book",
                            Price = 12000L,
                            UpdatedAt = new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8469)
                        },
                        new
                        {
                            Id = new Guid("eca7fc27-91ba-4114-862e-f4ecf13900f1"),
                            CreatedAt = new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8472),
                            Description = "Best resource for learning Entity Framework Core",
                            Name = "Entity Framework Core Book",
                            Price = 14000L,
                            UpdatedAt = new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8473)
                        },
                        new
                        {
                            Id = new Guid("c85591c9-5b83-4cd6-8322-0e205a28ac52"),
                            CreatedAt = new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8476),
                            Description = "Best resource for learning Blazor",
                            Name = "Blazor Book",
                            Price = 12000L,
                            UpdatedAt = new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8477)
                        },
                        new
                        {
                            Id = new Guid("f6acaf24-5826-486b-bb40-b369b9a59e2e"),
                            CreatedAt = new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8480),
                            Description = "Best resource for learning about RESTful Api's",
                            Name = "RESTful Api Book",
                            Price = 20000L,
                            UpdatedAt = new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8481)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}