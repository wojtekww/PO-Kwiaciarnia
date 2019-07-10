using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwiaciarnia.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if(!context.Products.Any())
            {
                context.AddRange
                    (
                    new Product { Id = 1, Name = "Róża", Category = "Kwiaty cięte", Price = 5.99M, Description = "Opis róży", ImageUrl = "images/roza.jpg", IsOnPromotion = false },
                    new Product { Id = 2, Name = "Tulipan", Category = "Kwiaty cięte", Price = 3.99M, Description = "Opis tulipana", ImageUrl = "images/tulipan.jpg", IsOnPromotion = false },
                    new Product { Id = 3, Name = "Doniczka mała", Category = "Akcesoria", Price = 7.99M, Description = "Opis doniczki", ImageUrl = "images/doniczka.jpg", IsOnPromotion = false },
                    new Product { Id = 4, Name = "Bukiet wiosenny", Category = "Bukiety", Price = 3.99M, Description = "Opis bukietu", ImageUrl = "images/bukiet_wiosenny.jpg", IsOnPromotion = false }

                    );

                context.SaveChanges();
            }
        }
    }
}
