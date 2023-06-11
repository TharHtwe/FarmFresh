using FarmFresh_API.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmFresh_API.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
                new Admin { Id = 1, Name = "Administrator", Email = "admin@gmail.com", Password = "$2b$12$kp5oS/Gluq7QX4/BFQTjueQ9Q67rixEL8gvrWOVcZQdDNZ493kgVO" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "User", LastName = "A", Email = "user@gmail.com", Password = "$2b$12$aND30iqZygFphzPq9b81OutbphY6sV6sT5bCbGcRYbYZIgglZmByi" }
            );

            modelBuilder.Entity<Unit>().HasData(
                new Unit { Id = 1, Name = "Packet", Description = "Packet of 1 bundle" },
                new Unit { Id = 2, Name = "Piece(s)" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fruit and Veg" },
                new Category { Id = 2, Name = "Meat & Seafood" },
                new Category { Id = 3, Name = "Dairy and Chilled" },
                new Category { Id = 4, Name = "Bakery" },
                new Category { Id = 5, Name = "Beverages" }
            );

            #region Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Ripe Blue Grapes",
                    Description = "Ripe Blue Grape is a product from ........",
                    Images = "Resources\\Images\\Untitled-1.png,Resources\\Images\\Untitled-3.png,Resources\\Images\\Untitled-8.png,Resources\\Images\\Untitled-9.png",
                    CountryOfOrigin = "France",
                    NewArrival = true,
                    OnPromotion = true
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Spinach",
                    Description = "Spinach is a product from ........",
                    Images = "Resources\\Images\\spinach.png",
                    CountryOfOrigin = "France",
                    NewArrival = true,
                    OnPromotion = true
                }, new Product
                {
                    Id = 3,
                    CategoryId = 2,
                    Name = "Salmon",
                    Description = "Freshly imported from ........",
                    Images = "Resources\\Images\\Untitled-7.png",
                    CountryOfOrigin = "France",
                    NewArrival = true,
                    OnPromotion = true
                }, new Product
                {
                    Id = 4,
                    CategoryId = 1,
                    Name = "Capsicum",
                    Description = "Capsicum is a product from ........",
                    Images = "Resources\\Images\\Untitled-5.png",
                    CountryOfOrigin = "France",
                    NewArrival = true,
                    OnPromotion = true
                }, new Product
                {
                    Id = 5,
                    CategoryId = 1,
                    Name = "Tomato",
                    Description = "Tomato is a product from ........",
                    Images = "Resources\\Images\\Untitled-2.png",
                    CountryOfOrigin = "France",
                    NewArrival = true,
                    OnPromotion = true
                }, new Product
                {
                    Id = 6,
                    CategoryId = 1,
                    Name = "Broccoli",
                    Description = "Broccoli is a product from ........",
                    Images = "Resources\\Images\\broccoli.png",
                    CountryOfOrigin = "France",
                    NewArrival = true,
                    OnPromotion = true
                }
            );
            #endregion
            modelBuilder.Entity<ProductStock>().HasData(
                new ProductStock { ProductId = 1, UnitId = 1, Price = 100, Instock = 100 },
                new ProductStock { ProductId = 2, UnitId = 1, Price = 200, Instock = 100 },
                new ProductStock { ProductId = 3, UnitId = 1, Price = 300, Instock = 100 },
                new ProductStock { ProductId = 4, UnitId = 1, Price = 400, Instock = 100 },
                new ProductStock { ProductId = 5, UnitId = 1, Price = 500, Instock = 100 },
                new ProductStock { ProductId = 6, UnitId = 1, Price = 600, Instock = 100 }
            );
        }
    }
}
