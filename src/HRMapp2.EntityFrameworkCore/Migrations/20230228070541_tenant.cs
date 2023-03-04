using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMapp2.Migrations
{
    /// <inheritdoc />
    public partial class tenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AppProjects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AppEmployees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AppDepartments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AppDepartmentProjects",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppProjects");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppEmployees");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppDepartments");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppDepartmentProjects");
        }
    }
}
