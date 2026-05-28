using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW21.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", maxLength: 15, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChassisNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalExaminationCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TurnCount = table.Column<int>(type: "int", nullable: false),
                    VisitTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalExaminationCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalExaminationCenters_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TechnicalExaminationCenters_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProvidingServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenterId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    TimeRange = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TakingTurns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    SelectedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CarId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakingTurns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TakingTurns_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TakingTurns_Cars_CarId1",
                        column: x => x.CarId1,
                        principalTable: "Cars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TakingTurns_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TakingTurns_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TakingTurns_TechnicalExaminationCenters_CenterId",
                        column: x => x.CenterId,
                        principalTable: "TechnicalExaminationCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TakingTurns_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ChassisNumber",
                table: "Cars",
                column: "ChassisNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CreatedAt",
                table: "Cars",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CreatedAt",
                table: "Cities",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidingServices_CenterId",
                table: "ProvidingServices",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidingServices_CreatedAt",
                table: "ProvidingServices",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TakingTurns_CarId",
                table: "TakingTurns",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_TakingTurns_CarId1",
                table: "TakingTurns",
                column: "CarId1");

            migrationBuilder.CreateIndex(
                name: "IX_TakingTurns_CenterId",
                table: "TakingTurns",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_TakingTurns_CityId",
                table: "TakingTurns",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TakingTurns_CreatedAt",
                table: "TakingTurns",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TakingTurns_ProvinceId",
                table: "TakingTurns",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_TakingTurns_UserId",
                table: "TakingTurns",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalExaminationCenters_CityId",
                table: "TechnicalExaminationCenters",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalExaminationCenters_CreatedAt",
                table: "TechnicalExaminationCenters",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalExaminationCenters_ProvinceId",
                table: "TechnicalExaminationCenters",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedAt",
                table: "Users",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProvidingServices");

            migrationBuilder.DropTable(
                name: "TakingTurns");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "TechnicalExaminationCenters");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
