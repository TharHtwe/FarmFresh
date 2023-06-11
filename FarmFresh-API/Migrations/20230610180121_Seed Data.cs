using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmFresh_API.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "Name", "Password", "Token" },
                values: new object[] { 1, "admin@gmail.com", "Administrator", "$2b$12$kp5oS/Gluq7QX4/BFQTjueQ9Q67rixEL8gvrWOVcZQdDNZ493kgVO", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fruit and Veg" },
                    { 2, "Meat & Seafood" },
                    { 3, "Dairy and Chilled" },
                    { 4, "Bakery" },
                    { 5, "Beverages" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Packet of 1 bundle", "Packet" },
                    { 2, null, "Piece(s)" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Token" },
                values: new object[] { 1, "user@gmail.com", "User", "A", "$2b$12$aND30iqZygFphzPq9b81OutbphY6sV6sT5bCbGcRYbYZIgglZmByi", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CountryOfOrigin", "Description", "Images", "Name", "NewArrival", "OnPromotion" },
                values: new object[,]
                {
                    { 1, 1, "France", "Ripe Blue Grape is a product from ........", "Resources\\Images\\Untitled-1.png,Resources\\Images\\Untitled-3.png,Resources\\Images\\Untitled-8.png,Resources\\Images\\Untitled-9.png", "Ripe Blue Grapes", true, true },
                    { 2, 1, "France", "Spinach is a product from ........", "Resources\\Images\\spinach.png", "Spinach", true, true },
                    { 3, 2, "France", "Freshly imported from ........", "Resources\\Images\\Untitled-7.png", "Salmon", true, true },
                    { 4, 1, "France", "Capsicum is a product from ........", "Resources\\Images\\Untitled-5.png", "Capsicum", true, true },
                    { 5, 1, "France", "Tomato is a product from ........", "Resources\\Images\\Untitled-2.png", "Tomato", true, true },
                    { 6, 1, "France", "Broccoli is a product from ........", "Resources\\Images\\broccoli.png", "Broccoli", true, true }
                });

            migrationBuilder.InsertData(
                table: "ProductStock",
                columns: new[] { "ProductId", "UnitId", "Instock", "Price" },
                values: new object[,]
                {
                    { 1, 1, 100, 100m },
                    { 2, 1, 100, 200m },
                    { 3, 1, 100, 300m },
                    { 4, 1, 100, 400m },
                    { 5, 1, 100, 500m },
                    { 6, 1, 100, 600m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductStock",
                keyColumns: new[] { "ProductId", "UnitId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductStock",
                keyColumns: new[] { "ProductId", "UnitId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductStock",
                keyColumns: new[] { "ProductId", "UnitId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProductStock",
                keyColumns: new[] { "ProductId", "UnitId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ProductStock",
                keyColumns: new[] { "ProductId", "UnitId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ProductStock",
                keyColumns: new[] { "ProductId", "UnitId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
