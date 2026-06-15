using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW21.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TakingTurns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CityName",
                value: "Shiraz");

            migrationBuilder.UpdateData(
                table: "TakingTurns",
                keyColumn: "Id",
                keyValue: 4,
                column: "CityName",
                value: "Esfahan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TakingTurns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CityName",
                value: "Tehran");

            migrationBuilder.UpdateData(
                table: "TakingTurns",
                keyColumn: "Id",
                keyValue: 4,
                column: "CityName",
                value: "Karaj");
        }
    }
}
