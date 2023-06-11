using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmFresh_API.Migrations
{
    public partial class Addproductsoriginarrivalunitdesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryOfOrigin",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NewArrival",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OnPromotion",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "CountryOfOrigin",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NewArrival",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OnPromotion",
                table: "Products");
        }
    }
}
