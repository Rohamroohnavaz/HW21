using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW21.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TheMostChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TakingTurns_TimeManaging_TimeId",
                table: "TakingTurns");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeManaging_TechnicalExaminationCenters_CenterId",
                table: "TimeManaging");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeManaging",
                table: "TimeManaging");

            migrationBuilder.RenameTable(
                name: "TimeManaging",
                newName: "Times");

            migrationBuilder.RenameIndex(
                name: "IX_TimeManaging_CenterId",
                table: "Times",
                newName: "IX_Times_CenterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Times",
                table: "Times",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TakingTurns_Times_TimeId",
                table: "TakingTurns",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Times_TechnicalExaminationCenters_CenterId",
                table: "Times",
                column: "CenterId",
                principalTable: "TechnicalExaminationCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TakingTurns_Times_TimeId",
                table: "TakingTurns");

            migrationBuilder.DropForeignKey(
                name: "FK_Times_TechnicalExaminationCenters_CenterId",
                table: "Times");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Times",
                table: "Times");

            migrationBuilder.RenameTable(
                name: "Times",
                newName: "TimeManaging");

            migrationBuilder.RenameIndex(
                name: "IX_Times_CenterId",
                table: "TimeManaging",
                newName: "IX_TimeManaging_CenterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeManaging",
                table: "TimeManaging",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TakingTurns_TimeManaging_TimeId",
                table: "TakingTurns",
                column: "TimeId",
                principalTable: "TimeManaging",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeManaging_TechnicalExaminationCenters_CenterId",
                table: "TimeManaging",
                column: "CenterId",
                principalTable: "TechnicalExaminationCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
