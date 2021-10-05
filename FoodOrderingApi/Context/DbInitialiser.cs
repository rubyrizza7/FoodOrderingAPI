using FoodOrderingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Context
{
    public static class DbInitializer
    {
        public static void Initialize(OrderingContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.MenuItems.Any())
            {
                return;   // DB has been seeded
            }

            var menuItems = new MenuItem[]
            {
            new MenuItem{Name="Pizza",Description="Yum",Price=11.50}
            
            };
            foreach (MenuItem s in menuItems)
            {
                context.MenuItems.Add(s);
            }
            context.SaveChanges();

            
        }
    }
}
