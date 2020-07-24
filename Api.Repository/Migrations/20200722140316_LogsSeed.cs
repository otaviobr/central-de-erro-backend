using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Repository.Migrations
{
    public partial class LogsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "id", "Description", "Frequency", "Level", "Origin" },
                values: new object[,]
                {
                    { 1, "Description 1", 1000, "High", "OnModelCreating" },
                    { 2, "Description 2", 2000, "High", "OnModelCreating" },
                    { 3, "Description 3", 3000, "High", "OnModelCreating" },
                    { 4, "Description 4", 4000, "High", "OnModelCreating" },
                    { 5, "Description 5", 5000, "High", "OnModelCreating" },
                    { 6, "Description 6", 6000, "High", "OnModelCreating" },
                    { 7, "Description 7", 7000, "High", "OnModelCreating" },
                    { 8, "Description 8", 8000, "High", "OnModelCreating" },
                    { 9, "Description 9", 9000, "High", "OnModelCreating" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 9);
        }
    }
}
