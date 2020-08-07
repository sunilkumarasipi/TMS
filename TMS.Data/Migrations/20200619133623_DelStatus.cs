using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMS.Data.Migrations
{
    public partial class DelStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DelBy",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DelDate",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DelStatus",
                table: "Student",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DelBy",
                table: "School",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DelDate",
                table: "School",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DelStatus",
                table: "School",
                maxLength: 1,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelBy",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "DelDate",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "DelStatus",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "DelBy",
                table: "School");

            migrationBuilder.DropColumn(
                name: "DelDate",
                table: "School");

            migrationBuilder.DropColumn(
                name: "DelStatus",
                table: "School");
        }
    }
}
