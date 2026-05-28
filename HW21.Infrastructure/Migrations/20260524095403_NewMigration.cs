using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW21.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_ProvidingServices_TechnicalExaminationCenters_CenterId",
                table: "ProvidingServices");

            migrationBuilder.DropForeignKey(
                name: "FK_TakingTurns_Cities_CityId",
                table: "TakingTurns");

            migrationBuilder.DropForeignKey(
                name: "FK_TakingTurns_Provinces_ProvinceId",
                table: "TakingTurns");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalExaminationCenters_Cities_CityId",
                table: "TechnicalExaminationCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalExaminationCenters_Provinces_ProvinceId",
                table: "TechnicalExaminationCenters");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProvidingServices_TechnicalExaminationCenters_CenterId",
                table: "ProvidingServices",
                column: "CenterId",
                principalTable: "TechnicalExaminationCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TakingTurns_Cities_CityId",
                table: "TakingTurns",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TakingTurns_Provinces_ProvinceId",
                table: "TakingTurns",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalExaminationCenters_Cities_CityId",
                table: "TechnicalExaminationCenters",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalExaminationCenters_Provinces_ProvinceId",
                table: "TechnicalExaminationCenters",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_ProvidingServices_TechnicalExaminationCenters_CenterId",
                table: "ProvidingServices");

            migrationBuilder.DropForeignKey(
                name: "FK_TakingTurns_Cities_CityId",
                table: "TakingTurns");

            migrationBuilder.DropForeignKey(
                name: "FK_TakingTurns_Provinces_ProvinceId",
                table: "TakingTurns");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalExaminationCenters_Cities_CityId",
                table: "TechnicalExaminationCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalExaminationCenters_Provinces_ProvinceId",
                table: "TechnicalExaminationCenters");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProvidingServices_TechnicalExaminationCenters_CenterId",
                table: "ProvidingServices",
                column: "CenterId",
                principalTable: "TechnicalExaminationCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TakingTurns_Cities_CityId",
                table: "TakingTurns",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TakingTurns_Provinces_ProvinceId",
                table: "TakingTurns",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalExaminationCenters_Cities_CityId",
                table: "TechnicalExaminationCenters",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalExaminationCenters_Provinces_ProvinceId",
                table: "TechnicalExaminationCenters",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
