using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveApplication.Migrations
{
    /// <inheritdoc />
    public partial class removeLeaveSearch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveForms_LeaveSearchViewModel_LeaveSearchViewModelSearchTerm",
                table: "LeaveForms");

            migrationBuilder.DropTable(
                name: "LeaveSearchViewModel");

            migrationBuilder.DropIndex(
                name: "IX_LeaveForms_LeaveSearchViewModelSearchTerm",
                table: "LeaveForms");

            migrationBuilder.DropColumn(
                name: "LeaveSearchViewModelSearchTerm",
                table: "LeaveForms");

            migrationBuilder.UpdateData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 2,
                column: "ApplicationDate",
                value: new DateTime(2024, 4, 10, 20, 45, 46, 519, DateTimeKind.Local).AddTicks(5839));

            migrationBuilder.UpdateData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 3,
                column: "ApplicationDate",
                value: new DateTime(2024, 4, 10, 20, 45, 46, 519, DateTimeKind.Local).AddTicks(6028));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LeaveSearchViewModelSearchTerm",
                table: "LeaveForms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LeaveSearchViewModel",
                columns: table => new
                {
                    SearchTerm = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FkEmployeeId = table.Column<int>(type: "int", nullable: false),
                    FkLeaveForm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveSearchViewModel", x => x.SearchTerm);
                });

            migrationBuilder.UpdateData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 2,
                columns: new[] { "ApplicationDate", "LeaveSearchViewModelSearchTerm" },
                values: new object[] { new DateTime(2024, 4, 10, 20, 4, 8, 944, DateTimeKind.Local).AddTicks(5931), null });

            migrationBuilder.UpdateData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 3,
                columns: new[] { "ApplicationDate", "LeaveSearchViewModelSearchTerm" },
                values: new object[] { new DateTime(2024, 4, 10, 20, 4, 8, 944, DateTimeKind.Local).AddTicks(5998), null });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveForms_LeaveSearchViewModelSearchTerm",
                table: "LeaveForms",
                column: "LeaveSearchViewModelSearchTerm");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveForms_LeaveSearchViewModel_LeaveSearchViewModelSearchTerm",
                table: "LeaveForms",
                column: "LeaveSearchViewModelSearchTerm",
                principalTable: "LeaveSearchViewModel",
                principalColumn: "SearchTerm");
        }
    }
}
