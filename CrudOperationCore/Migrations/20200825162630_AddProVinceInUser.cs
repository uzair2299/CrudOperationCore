using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudOperationCore.Migrations
{
    public partial class AddProVinceInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProvinceName",
                table: "Provinces",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProvinceId",
                table: "Users",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Provinces_ProvinceId",
                table: "Users",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Provinces_ProvinceId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProvinceId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "ProvinceName",
                table: "Provinces",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
