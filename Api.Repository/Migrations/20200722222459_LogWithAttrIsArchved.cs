using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Repository.Migrations
{
    public partial class LogWithAttrIsArchved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Logs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 2,
                column: "IsArchived",
                value: true);

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 4,
                column: "IsArchived",
                value: true);

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 6,
                column: "IsArchived",
                value: true);

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 8,
                column: "IsArchived",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Logs");
        }
    }
}
