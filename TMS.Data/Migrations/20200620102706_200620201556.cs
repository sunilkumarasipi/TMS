using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMS.Data.Migrations
{
    public partial class _200620201556 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    InsBy = table.Column<int>(nullable: false),
                    InsDate = table.Column<DateTime>(nullable: false),
                    ModiBy = table.Column<int>(nullable: true),
                    ModiDate = table.Column<DateTime>(nullable: true),
                    DelBy = table.Column<int>(nullable: true),
                    DelDate = table.Column<DateTime>(nullable: true),
                    DelStatus = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
