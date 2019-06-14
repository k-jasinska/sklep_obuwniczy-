using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Sandały",
                        Description = "danskie",
                        Category = "Lato",
                        Price = 25,
                        ImageName = "1.jpg"
                    },
                    new Product
                    {
                        Name = "Pantofle",
                        Description = "buty ładne",
                        Category = "Jesien",
                        Price = 50,
                        ImageName = "2.jpg"
                    },
                    new Product
                    {
                        Name = "Gumowce",
                        Description = "buty brzydkie",
                        Category = "Wiosna",
                        Price = 12,
                        ImageName = "3.jpg"
                    },
                    new Product
                    {
                        Name = "Klapki",
                        Description = "buty wygodne",
                        Category = "Lato",
                        Price = 15,
                        ImageName = "4.jpg"
                    },
                    new Product
                    {
                        Name = "Szpilki",
                        Description = "neiwygodne",
                        Category = "damskie",
                        Price = 70,
                        ImageName = "5.jpg"
                    },
                    new Product
                    {
                        Name = "Półbuty",
                        Description = "neiwygodne, niełądne",
                        Category = "Inne",
                        Price = 10,
                        ImageName = "6.jpg"
                    },
                    new Product
                    {
                        Name = "Baletki",
                        Description = "łądne",
                        Category = "Inne",
                        Price = 30,
                        ImageName = "7.jpg"
                    },
                    new Product
                    {
                        Name = "Trampki",
                        Description = "łądne",
                        Category = "Inne",
                        Price = 17,
                        ImageName = "8.jpg"
                    },
                    new Product
                    {
                        Name = "Adidasy",
                        Description = "wygodne",
                        Category = "Inne",
                        Price = 80,
                        ImageName = "9.jpg"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
