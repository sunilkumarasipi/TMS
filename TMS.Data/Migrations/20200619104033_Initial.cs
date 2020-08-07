using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMS.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    SchoolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    InsBy = table.Column<int>(nullable: false),
                    InsDate = table.Column<DateTime>(nullable: false),
                    ModiBy = table.Column<int>(nullable: false),
                    ModiDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    Class = table.Column<string>(maxLength: 5, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    SchoolId = table.Column<int>(nullable: false),
                    GuardianName = table.Column<string>(maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(maxLength: 15, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Fees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Photo = table.Column<byte[]>(nullable: true),
                    InsBy = table.Column<int>(nullable: false),
                    InsDate = table.Column<DateTime>(nullable: false),
                    ModiBy = table.Column<int>(nullable: true),
                    ModiDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_SchoolId",
                table: "Student",
                column: "SchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "School");
        }
    }
}
