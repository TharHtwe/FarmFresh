﻿// <auto-generated />
using FarmFresh_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FarmFresh_API.Migrations
{
    [DbContext(typeof(FarmFreshDdContext))]
    partial class FarmFreshDdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FarmFresh_API.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@gmail.com",
                            Name = "Administrator",
                            Password = "$2b$12$kp5oS/Gluq7QX4/BFQTjueQ9Q67rixEL8gvrWOVcZQdDNZ493kgVO"
                        });
                });

            modelBuilder.Entity("FarmFresh_API.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fruit and Veg"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Meat & Seafood"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dairy and Chilled"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bakery"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Beverages"
                        });
                });

            modelBuilder.Entity("FarmFresh_API.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CountryOfOrigin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NewArrival")
                        .HasColumnType("bit");

                    b.Property<bool>("OnPromotion")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CountryOfOrigin = "France",
                            Description = "Ripe Blue Grape is a product from ........",
                            Images = "Resources\\Images\\Untitled-1.png,Resources\\Images\\Untitled-3.png,Resources\\Images\\Untitled-8.png,Resources\\Images\\Untitled-9.png",
                            Name = "Ripe Blue Grapes",
                            NewArrival = true,
                            OnPromotion = true
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CountryOfOrigin = "France",
                            Description = "Spinach is a product from ........",
                            Images = "Resources\\Images\\spinach.png",
                            Name = "Spinach",
                            NewArrival = true,
                            OnPromotion = true
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            CountryOfOrigin = "France",
                            Description = "Freshly imported from ........",
                            Images = "Resources\\Images\\Untitled-7.png",
                            Name = "Salmon",
                            NewArrival = true,
                            OnPromotion = true
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            CountryOfOrigin = "France",
                            Description = "Capsicum is a product from ........",
                            Images = "Resources\\Images\\Untitled-5.png",
                            Name = "Capsicum",
                            NewArrival = true,
                            OnPromotion = true
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            CountryOfOrigin = "France",
                            Description = "Tomato is a product from ........",
                            Images = "Resources\\Images\\Untitled-2.png",
                            Name = "Tomato",
                            NewArrival = true,
                            OnPromotion = true
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            CountryOfOrigin = "France",
                            Description = "Broccoli is a product from ........",
                            Images = "Resources\\Images\\broccoli.png",
                            Name = "Broccoli",
                            NewArrival = true,
                            OnPromotion = true
                        });
                });

            modelBuilder.Entity("FarmFresh_API.Models.ProductStock", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("Instock")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId", "UnitId");

                    b.HasIndex("UnitId");

                    b.ToTable("ProductStock");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            UnitId = 1,
                            Instock = 100,
                            Price = 100m
                        },
                        new
                        {
                            ProductId = 2,
                            UnitId = 1,
                            Instock = 100,
                            Price = 200m
                        },
                        new
                        {
                            ProductId = 3,
                            UnitId = 1,
                            Instock = 100,
                            Price = 300m
                        },
                        new
                        {
                            ProductId = 4,
                            UnitId = 1,
                            Instock = 100,
                            Price = 400m
                        },
                        new
                        {
                            ProductId = 5,
                            UnitId = 1,
                            Instock = 100,
                            Price = 500m
                        },
                        new
                        {
                            ProductId = 6,
                            UnitId = 1,
                            Instock = 100,
                            Price = 600m
                        });
                });

            modelBuilder.Entity("FarmFresh_API.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Packet of 1 bundle",
                            Name = "Packet"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Piece(s)"
                        });
                });

            modelBuilder.Entity("FarmFresh_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "user@gmail.com",
                            FirstName = "User",
                            LastName = "A",
                            Password = "$2b$12$aND30iqZygFphzPq9b81OutbphY6sV6sT5bCbGcRYbYZIgglZmByi"
                        });
                });

            modelBuilder.Entity("FarmFresh_API.Models.Product", b =>
                {
                    b.HasOne("FarmFresh_API.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FarmFresh_API.Models.ProductStock", b =>
                {
                    b.HasOne("FarmFresh_API.Models.Product", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FarmFresh_API.Models.Unit", "Unit")
                        .WithMany("Stocks")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("FarmFresh_API.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FarmFresh_API.Models.Product", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("FarmFresh_API.Models.Unit", b =>
                {
                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
