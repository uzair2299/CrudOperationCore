using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore.Models
{
    public static class SeedData
    {/// <summary>
     ///  The EnsurePopulated method obtains an ApplicationDbContext object through the
     ///IApplicationBuilder interface and uses it to check whether there are any Product objects in the database.
    /// </summary>

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var scopeeee = app.ApplicationServices.CreateScope();
            ApplicationContext applicationContext = scopeeee.ServiceProvider.GetRequiredService<ApplicationContext>();
            if (!applicationContext.EShopProducts.Any())
            {
                applicationContext.EShopProducts.AddRange(
                    new EShopProduct
                    {
                        Name = "Kayak",
                        Description = "A boat for one person",
                        Category = "Watersports",
                        Price = 275
                    },
                    new EShopProduct
                    {
                        Name = "Lifejacket",
                        Description = "Protective and fashionable",
                        Category = "Watersports",
                        Price = 48.95m
                    },
                    new EShopProduct
                    {
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        Category = "Soccer",
                        Price = 19.50m
                    },
                    new EShopProduct
                    {
                        Name = "Corner Flags",
                        Description = "Give your playing field a professional touch",
                        Category = "Soccer",
                        Price = 34.95m
                    },
                    new EShopProduct
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = "Soccer",
                        Price = 79500
                    },
                    new EShopProduct
                    {
                        Name = "Thinking Cap",
                        Description = "Improve brain efficiency by 75%",
                        Category = "Chess",
                        Price = 16
                    },
                    new EShopProduct
                    {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent a disadvantage",
                        Category = "Chess",
                        Price = 29.95m
                    },
                    new EShopProduct
                    {
                        Name = "Human Chess Board",
                        Description = "A fun game for the family",
                        Category = "Chess",
                        Price = 75
                    },
                    new EShopProduct
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King",
                        Category = "Chess",
                        Price = 1200
                    }
                    );
                applicationContext.SaveChanges();
            }
        }
    }
}
