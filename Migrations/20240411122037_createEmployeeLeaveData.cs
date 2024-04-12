using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveApplication.Migrations
{
    /// <inheritdoc />
    public partial class createEmployeeLeaveData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 6, "Nelly", "Nordlund" },
                    { 7, "Melissa", "Wallström" }
                });

            migrationBuilder.UpdateData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 2,
                columns: new[] { "ApplicationDate", "FkEmployeeId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 11, 14, 20, 36, 632, DateTimeKind.Local).AddTicks(5927), 5, new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 3,
                columns: new[] { "ApplicationDate", "FkEmployeeId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 11, 14, 20, 36, 632, DateTimeKind.Local).AddTicks(5992), 6, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "LeaveForms",
                columns: new[] { "LeaveApplicationId", "ApplicationDate", "EndDate", "FkEmployeeId", "StartDate", "Type" },
                values: new object[] { 4, new DateTime(2024, 4, 11, 14, 20, 36, 632, DateTimeKind.Local).AddTicks(5995), new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName" },
                values: new object[] { 4, "Nelly", "Nordlund" });

            migrationBuilder.UpdateData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 2,
                columns: new[] { "ApplicationDate", "FkEmployeeId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 11, 14, 14, 37, 367, DateTimeKind.Local).AddTicks(4087), 4, new DateTime(24, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "LeaveForms",
                keyColumn: "LeaveApplicationId",
                keyValue: 3,
                columns: new[] { "ApplicationDate", "FkEmployeeId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 11, 14, 14, 37, 367, DateTimeKind.Local).AddTicks(4154), 5, new DateTime(24, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
