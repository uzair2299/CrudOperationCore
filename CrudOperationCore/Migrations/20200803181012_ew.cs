using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudOperationCore.Migrations
{
    public partial class ew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_countries_ProvinceId",
                table: "cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cities",
                table: "cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_countries",
                table: "countries");

            migrationBuilder.RenameTable(
                name: "cities",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "countries",
                newName: "Provinces");

            migrationBuilder.RenameIndex(
                name: "IX_cities_ProvinceId",
                table: "Cities",
                newName: "IX_Cities_ProvinceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "cities");

            migrationBuilder.RenameTable(
                name: "Provinces",
                newName: "countries");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_ProvinceId",
                table: "cities",
                newName: "IX_cities_ProvinceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cities",
                table: "cities",
                column: "CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_countries",
                table: "countries",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_countries_ProvinceId",
                table: "cities",
                column: "ProvinceId",
                principalTable: "countries",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
