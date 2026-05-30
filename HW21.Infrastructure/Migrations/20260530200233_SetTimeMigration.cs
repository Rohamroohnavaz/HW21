using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW21.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetTimeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_TakingTurns_Cities_CityId",
                table: "TakingTurns");

            migrationBuilder.DropForeignKey(
                name: "FK_TakingTurns_Provinces_ProvinceId",
                table: "TakingTurns");

            migrationBuilder.DropTable(
                name: "ProvidingServices");

            migrationBuilder.DropColumn(
                name: "SelectedTime",
                table: "TakingTurns");

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "TechnicalExaminationCenters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultText",
                table: "TakingTurns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TimeId",
                table: "TakingTurns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TimeManaging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeManaging", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeManaging_TechnicalExaminationCenters_CenterId",
                        column: x => x.CenterId,
                        principalTable: "TechnicalExaminationCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalExaminationCenters_CityId1",
                table: "TechnicalExaminationCenters",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_TakingTurns_TimeId",
                table: "TakingTurns",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeManaging_CenterId",
                table: "TimeManaging",
                column: "CenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_TakingTurns_TimeManaging_TimeId",
                table: "TakingTurns",
                column: "TimeId",
                principalTable: "TimeManaging",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalExaminationCenters_Cities_CityId1",
                table: "TechnicalExaminationCenters",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_TakingTurns_Cities_CityId",
                table: "TakingTurns");

            migrationBuilder.DropForeignKey(
                name: "FK_TakingTurns_Provinces_ProvinceId",
                table: "TakingTurns");

            migrationBuilder.DropForeignKey(
                name: "FK_TakingTurns_TimeManaging_TimeId",
                table: "TakingTurns");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalExaminationCenters_Cities_CityId1",
                table: "TechnicalExaminationCenters");

            migrationBuilder.DropTable(
                name: "TimeManaging");

            migrationBuilder.DropIndex(
                name: "IX_TechnicalExaminationCenters_CityId1",
                table: "TechnicalExaminationCenters");

            migrationBuilder.DropIndex(
                name: "IX_TakingTurns_TimeId",
                table: "TakingTurns");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "TechnicalExaminationCenters");

            migrationBuilder.DropColumn(
                name: "ResultText",
                table: "TakingTurns");

            migrationBuilder.DropColumn(
                name: "TimeId",
                table: "TakingTurns");

            migrationBuilder.AddColumn<DateTime>(
                name: "SelectedTime",
                table: "TakingTurns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ProvidingServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenterId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimeRange = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidingServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvidingServices_TechnicalExaminationCenters_CenterId",
                        column: x => x.CenterId,
                        principalTable: "TechnicalExaminationCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProvidingServices_CenterId",
                table: "ProvidingServices",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidingServices_CreatedAt",
                table: "ProvidingServices",
                column: "CreatedAt");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "Users",
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
        }
    }
}
