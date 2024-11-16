using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRegistrationApp.Migrations
{
    public partial class UpdateEmployeeSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10);

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "Department", "Email", "HireDate", "Name", "PhoneNumber", "Position", "Salary", "Status" },
                values: new object[] { 1, "123 Main St, City A", "Human Resources", "john.doe@example.com", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", "9876543210", "Manager", 80000m, "Active" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "Department", "Email", "HireDate", "Name", "PhoneNumber", "Position", "Salary", "Status" },
                values: new object[] { 10, "789 Fir St, City J", "Human Resources", "laura.martin@example.com", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura Martin", "7894561230", "HR Assistant", 55000m, "Active" });
        }
    }
}
