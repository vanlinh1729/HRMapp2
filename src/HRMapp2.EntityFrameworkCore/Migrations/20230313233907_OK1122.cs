using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMapp2.Migrations
{
    /// <inheritdoc />
    public partial class OK1122 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppEmployees_AppDepartments_DepartmentId",
                table: "AppEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_AppEmployees_AppDepartments_DepartmentId1",
                table: "AppEmployees");

            migrationBuilder.DropIndex(
                name: "IX_AppEmployees_DepartmentId",
                table: "AppEmployees");

            migrationBuilder.DropIndex(
                name: "IX_AppEmployees_DepartmentId1",
                table: "AppEmployees");

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "AppEmployees");

            migrationBuilder.CreateTable(
                name: "AppDepartmentEmployees",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDepartmentEmployees", x => new { x.DepartmentId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_AppDepartmentEmployees_AppDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AppDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppDepartmentEmployees_AppEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AppEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentEmployees_DepartmentId_EmployeeId",
                table: "AppDepartmentEmployees",
                columns: new[] { "DepartmentId", "EmployeeId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartmentEmployees_EmployeeId",
                table: "AppDepartmentEmployees",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppDepartmentEmployees");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId1",
                table: "AppEmployees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployees_DepartmentId",
                table: "AppEmployees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployees_DepartmentId1",
                table: "AppEmployees",
                column: "DepartmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppEmployees_AppDepartments_DepartmentId",
                table: "AppEmployees",
                column: "DepartmentId",
                principalTable: "AppDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppEmployees_AppDepartments_DepartmentId1",
                table: "AppEmployees",
                column: "DepartmentId1",
                principalTable: "AppDepartments",
                principalColumn: "Id");
        }
    }
}
