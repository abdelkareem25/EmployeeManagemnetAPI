using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmpMangSys.Repository.DataBaseContext.DataMigration
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 6, 2, 55, 59, 298, DateTimeKind.Local).AddTicks(7145), "Human Resources", "HR" },
                    { 2, new DateTime(2026, 3, 6, 2, 55, 59, 298, DateTimeKind.Local).AddTicks(7579), "Information Technology", "IT" },
                    { 3, new DateTime(2026, 3, 6, 2, 55, 59, 298, DateTimeKind.Local).AddTicks(7582), "Financial Department", "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "DepartmentId", "Email", "FullName", "HireDate", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 6, 2, 55, 59, 298, DateTimeKind.Local).AddTicks(7815), 3, "HamzaAbdelkarim@gmail.com", "Hamza Abdelkarim", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01002594587", 32000m },
                    { 2, new DateTime(2026, 3, 6, 2, 55, 59, 298, DateTimeKind.Local).AddTicks(7823), 1, "LailaAbdelkarim@gmail.com", "Laila Abdelkarim", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01002003330", 25000m },
                    { 3, new DateTime(2026, 3, 6, 2, 55, 59, 298, DateTimeKind.Local).AddTicks(7827), 2, "NourAbdelkarim@gmail.com", "Nour Abdelkarim", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01001004499", 32000m },
                    { 4, new DateTime(2026, 3, 6, 2, 55, 59, 298, DateTimeKind.Local).AddTicks(7829), 1, "JasminAbdelkarim@gmail.com", "Jasmin Abdelkarim", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01022594587", 22000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
