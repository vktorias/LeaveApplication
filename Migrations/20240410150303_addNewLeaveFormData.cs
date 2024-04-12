using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveApplication.Migrations
{
    /// <inheritdoc />
    public partial class addNewLeaveFormData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveForms",
                columns: new[] { "LeaveApplicationId", "ApplicationDate", "EndDate", "FkEmployeeId", "StartDate", "Type" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 4, 10, 17, 3, 3, 251, DateTimeKind.Local).AddTicks(695), new DateTime(24, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(24, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2024, 4, 10, 17, 3, 3, 251, DateTimeKind.Local).AddTicks(763), new DateTime(24, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(24, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 3);
        }
    }
}
