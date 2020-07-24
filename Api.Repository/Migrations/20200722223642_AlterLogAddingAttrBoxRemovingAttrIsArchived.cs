using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Repository.Migrations
{
    public partial class AlterLogAddingAttrBoxRemovingAttrIsArchived : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Logs");

            migrationBuilder.AddColumn<string>(
                name: "Box",
                table: "Logs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 1,
                column: "Box",
                value: "archive");

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 2,
                column: "Box",
                value: "primary");

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 3,
                column: "Box",
                value: "archive");

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 4,
                column: "Box",
                value: "primary");

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 5,
                column: "Box",
                value: "archive");

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 6,
                column: "Box",
                value: "primary");

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 7,
                column: "Box",
                value: "archive");

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 8,
                column: "Box",
                value: "primary");

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "id",
                keyValue: 9,
                column: "Box",
                value: "archive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Box",
                table: "Logs");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Logs",
                type: "boolean",
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
    }
}
