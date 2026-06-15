using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HW21.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixAllChangesMigration : Migration
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
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
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
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId1 = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_TechnicalExaminationCenters_Cities_CityId1",
                        column: x => x.CityId1,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TechnicalExaminationCenters_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Times_TechnicalExaminationCenters_CenterId",
                        column: x => x.CenterId,
                        principalTable: "TechnicalExaminationCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TakingTurns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false),
                    ResultText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReserveStatus = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_TakingTurns_TechnicalExaminationCenters_CenterId",
                        column: x => x.CenterId,
                        principalTable: "TechnicalExaminationCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TakingTurns_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1930, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Tehran" },
                    { 2, new DateTime(1932, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Alborz" },
                    { 3, new DateTime(1938, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Fars" },
                    { 4, new DateTime(1920, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Esfahan" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "987654321", 9351305594L, 1, "Roham_1234" },
                    { 2, new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "6387492", 9397821343L, 1, "Mamad_jkbg" },
                    { 3, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "123456789", 9905679299L, 1, "Taha_45d" },
                    { 4, new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "456123", 9196678932L, 1, "Ali_V88" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarName", "ChassisNumber", "CreatedAt", "IsDeleted", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, "MC Laren", "NABN3879823832", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 1 },
                    { 2, "207", "AHYU329875356", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 2 },
                    { 3, "Dodge Challenger", "POQA492378389", new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 3 },
                    { 4, "Tiwooli", "YBVZ193789132", new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 4 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, new DateTime(1800, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Tehran", 1 },
                    { 2, new DateTime(1812, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Karaj", 2 },
                    { 3, new DateTime(1812, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Shiraz", 3 },
                    { 4, new DateTime(1840, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "KhomeiniShahr", 4 }
                });

            migrationBuilder.InsertData(
                table: "TechnicalExaminationCenters",
                columns: new[] { "Id", "Address", "CityId", "CityId1", "CreatedAt", "EndTime", "IsDeleted", "Name", "ProvinceId", "StartTime", "Status", "TurnCount" },
                values: new object[,]
                {
                    { 1, "Tehran_", 1, null, new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Center 1", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 2, "Karaj_", 2, null, new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Center 2", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 3, "Shiraz_", 3, null, new DateTime(2020, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Center 3", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 4, "Ardabil_", 4, null, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Center 4", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "Id", "CenterId", "CreatedAt", "EndTime", "IsDeleted", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0), false, new TimeSpan(0, 5, 0, 0, 0) },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0), false, new TimeSpan(0, 2, 0, 0, 0) },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 30, 0, 0), false, new TimeSpan(0, 1, 0, 0, 0) },
                    { 4, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0), false, new TimeSpan(0, 4, 30, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "TakingTurns",
                columns: new[] { "Id", "Capacity", "CarId", "CarId1", "CenterId", "CityName", "CreatedAt", "IsDeleted", "ProvinceName", "ReserveStatus", "ResultText", "Status", "TimeId" },
                values: new object[,]
                {
                    { 1, 2, 1, null, 1, "Tehran", new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Tehran", 1, "Turn Is Available", 1, 1 },
                    { 2, 1, 2, null, 2, "Karaj", new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Alborz", 1, "Turn Is Available", 1, 2 },
                    { 3, 4, 3, null, 3, "Tehran", new DateTime(2026, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Tehran", 1, "Turn Is Available", 1, 3 },
                    { 4, 2, 4, null, 4, "Karaj", new DateTime(2026, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Alborz", 1, "Turn Is Available", 1, 4 }
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
                name: "IX_Provinces_CreatedAt",
                table: "Provinces",
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
                name: "IX_TakingTurns_CreatedAt",
                table: "TakingTurns",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TakingTurns_TimeId",
                table: "TakingTurns",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalExaminationCenters_CityId",
                table: "TechnicalExaminationCenters",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalExaminationCenters_CityId1",
                table: "TechnicalExaminationCenters",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalExaminationCenters_CreatedAt",
                table: "TechnicalExaminationCenters",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalExaminationCenters_ProvinceId",
                table: "TechnicalExaminationCenters",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Times_CenterId",
                table: "Times",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Times_CreatedAt",
                table: "Times",
                column: "CreatedAt");

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
                name: "TakingTurns");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TechnicalExaminationCenters");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
