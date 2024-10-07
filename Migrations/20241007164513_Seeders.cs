using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class Seeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "8a38aadc7750a045418aa21d714ecc32ae979d38c661ac754b2315ca4c51b351");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "8082737d4fa85b926cbfcbf74e2a878fa370cc47fbad7edac0cf9ef368d60db0");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "16cc5be8e058735655140998906d8885aa4f4b275dafacaccd179aef83ccb794");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "ab0a40c6b433a42890eb94616a3e658ba3a5bb91151b6ae31d876d2d3e636fc2");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "fdea530631444d3d1e6199c782e87cdb1df91235b7ec13e0c8027501f0b2815f");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "7d9b04b16f566e1a54f9793f29d20a7acbffd19fee6e367a441c5e41015c428e");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "123456789");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "JuanGonzalez123!");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AnaMartinez123!");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "LuisPerez123!");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "LauraHernandez123!");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "CarlosLopez123!");
        }
    }
}
