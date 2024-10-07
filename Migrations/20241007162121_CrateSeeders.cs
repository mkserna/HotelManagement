using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class CrateSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "id", "email", "firt_name", "identification_number", "last_name", "password" },
                values: new object[,]
                {
                    { 1, "maria@gmail.com", "Maria", "123456789", "Sanchez", "123456789" },
                    { 2, "juan@gmail.com", "Juan", "987654321", "Gonzalez", "JuanGonzalez123!" },
                    { 3, "ana@gmail.com", "Ana", "456789123", "Martinez", "AnaMartinez123!" },
                    { 4, "luis@gmail.com", "Luis", "321654987", "Perez", "LuisPerez123!" },
                    { 5, "laura@gmail.com", "Laura", "159753468", "Hernandez", "LauraHernandez123!" },
                    { 6, "carlos@gmail.com", "Carlos", "753159864", "Lopez", "CarlosLopez123!" }
                });

            migrationBuilder.InsertData(
                table: "room_types",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Una acogedora habitación básica con una cama individual, ideal para viajeros solos.", "Habitación Simple" },
                    { 2, "Ofrece flexibilidad con dos camas individuales o una cama doble, perfecta para parejas o amigos.", "Habitación Doble" },
                    { 3, " Espaciosa y lujosa, con una cama king size y una sala de estar separada, ideal para quienes buscan confort y exclusividad.", "Suite" },
                    { 4, "Diseñada para familias, con espacio adicional y varias camas para una estancia cómoda.", "Habitación Familiar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "room_types",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "room_types",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "room_types",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "room_types",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
