using FoodOrderingApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Context
{
    public class OrderingContext : DbContext
    {
        public OrderingContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Selection> Selections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map Selection - one to many with MenuItem and Cart - FK's as combo primary key
            var selectionEtb = modelBuilder.Entity<Selection>();
            selectionEtb.HasKey(cd => new { cd.MenuItemId, cd.CartId });
            

            // Map Order - one to one or zero
            modelBuilder.Entity<Order>()
            .HasOne(a => a.Cart)
            .WithOne(a => a.Order);


            // add some data
            modelBuilder.Entity<MenuItem>().HasData(new MenuItem
            {
                MenuItemId = 1,
                Name = "Pizza",
                Description = "Tomato, Cheese on base",
                Price = 11.50
            }, new MenuItem
            {
                MenuItemId = 2,
                Name = "Big Pizza",
                Description = "Lots of Tomato, Cheese on base",
                Price = 16.50
            });

            // add an empty cart to start off with
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                CartId = 1
            });
        }
    }
}
