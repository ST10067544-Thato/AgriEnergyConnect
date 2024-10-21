using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriEnergyConnect.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
            name: "FarmerID",
            table: "Products",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

            migrationBuilder.AlterColumn<int>(
            name: "FarmerID",
            table: "Products",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
            name: "FarmerID",
            table: "Products",
            type: "int",
            nullable: false,
            oldClrType: typeof(int),
            oldNullable: true);

            migrationBuilder.AlterColumn<int>(
            name: "FarmerID",
            table: "Products",
            type: "int",
            nullable: false,
            oldClrType: typeof(int),
            oldNullable: true);

        }
    }
}
