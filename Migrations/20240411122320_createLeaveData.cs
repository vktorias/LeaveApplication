using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveApplication.Migrations
{
    /// <inheritdoc />
    public partial class createLeaveData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 4,
                column: "ApplicationDate",
                value: new DateTime(2024, 4, 11, 14, 23, 19, 774, DateTimeKind.Local).AddTicks(396));

            migrationBuilder.InsertData(
                table: "LeaveForms",
                columns: new[] { "LeaveApplicationId", "ApplicationDate", "EndDate", "FkEmployeeId", "StartDate", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 11, 14, 23, 19, 774, DateTimeKind.Local).AddTicks(327), new DateTime(2024, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2024, 4, 11, 14, 23, 19, 774, DateTimeKind.Local).AddTicks(393), new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 4,
                column: "ApplicationDate",
                value: new DateTime(2024, 4, 11, 14, 20, 36, 632, DateTimeKind.Local).AddTicks(5995));

            migrationBuilder.InsertData(
                table: "LeaveForms",
                columns: new[] { "LeaveApplicationId", "ApplicationDate", "EndDate", "FkEmployeeId", "StartDate", "Type" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 4, 11, 14, 20, 36, 632, DateTimeKind.Local).AddTicks(5927), new DateTime(2024, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2024, 4, 11, 14, 20, 36, 632, DateTimeKind.Local).AddTicks(5992), new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });
        }
    }
}
