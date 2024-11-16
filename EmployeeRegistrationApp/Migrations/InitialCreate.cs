using Microsoft.EntityFrameworkCore.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Employees",
            columns: table => new
            {
                EmployeeId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(nullable: false),
                Email = table.Column<string>(nullable: false),
                Position = table.Column<string>(nullable: false),
                Address = table.Column<string>(nullable: true),
                Department = table.Column<string>(nullable: true),
                HireDate = table.Column<DateTime>(nullable: false),
                Salary = table.Column<decimal>(nullable: false),
                Status = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Employees", x => x.EmployeeId);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Employees");
    }
}
