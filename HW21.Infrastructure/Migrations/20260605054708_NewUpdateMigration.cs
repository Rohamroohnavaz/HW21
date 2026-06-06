using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW21.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TakingTurns_Cities_CityId",
                table: "TakingTurns");

            migrationBuilder.DropForeignKey(
                name: "FK_TakingTurns_Provinces_ProvinceId",
                table: "TakingTurns");

            migrationBuilder.DropForeignKey(
                name: "FK_TakingTurns_Users_UserId",
                table: "TakingTurns");

            migrationBuilder.DropIndex(
                name: "IX_TakingTurns_CityId",
                table: "TakingTurns");

            migrationBuilder.DropIndex(
                name: "IX_TakingTurns_ProvinceId",
                table: "TakingTurns");

            migrationBuilder.DropIndex(
                name: "IX_TakingTurns_UserId",
                table: "TakingTurns");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "TimeManaging");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "TakingTurns");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "TakingTurns");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TakingTurns",
                newName: "Capacity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "TakingTurns",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "TimeManaging",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "TakingTurns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "TakingTurns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TakingTurns_CityId",
                table: "TakingTurns",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TakingTurns_ProvinceId",
                table: "TakingTurns",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_TakingTurns_UserId",
                table: "TakingTurns",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TakingTurns_Cities_CityId",
                table: "TakingTurns",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TakingTurns_Provinces_ProvinceId",
                table: "TakingTurns",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TakingTurns_Users_UserId",
                table: "TakingTurns",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
