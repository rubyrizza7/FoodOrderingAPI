﻿// <auto-generated />
using System;
using FoodOrderingApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodOrderingApi.Migrations
{
    [DbContext(typeof(OrderingContext))]
    [Migration("20211028222120_addOrderAttributes")]
    partial class addOrderAttributes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodOrderingApi.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("CartId");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            CartId = 1,
                            TotalPrice = 0.0
                        });
                });

            modelBuilder.Entity("FoodOrderingApi.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("MenuItemId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            MenuItemId = 1,
                            Description = "Tomato, Cheese on base",
                            Name = "Pizza",
                            Price = 11.5
                        },
                        new
                        {
                            MenuItemId = 2,
                            Description = "Lots of Tomato, Cheese on base",
                            Name = "Big Pizza",
                            Price = 16.5
                        });
                });

            modelBuilder.Entity("FoodOrderingApi.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimePlaced")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("CartId")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FoodOrderingApi.Models.Selection", b =>
                {
                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("SelectionPrice")
                        .HasColumnType("float");

                    b.HasKey("MenuItemId", "CartId");

                    b.HasIndex("CartId");

                    b.ToTable("Selections");
                });

            modelBuilder.Entity("FoodOrderingApi.Models.Order", b =>
                {
                    b.HasOne("FoodOrderingApi.Models.Cart", "Cart")
                        .WithOne("Order")
                        .HasForeignKey("FoodOrderingApi.Models.Order", "CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("FoodOrderingApi.Models.Selection", b =>
                {
                    b.HasOne("FoodOrderingApi.Models.Cart", null)
                        .WithMany("Selections")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderingApi.Models.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("FoodOrderingApi.Models.Cart", b =>
                {
                    b.Navigation("Order");

                    b.Navigation("Selections");
                });
#pragma warning restore 612, 618
        }
    }
}
