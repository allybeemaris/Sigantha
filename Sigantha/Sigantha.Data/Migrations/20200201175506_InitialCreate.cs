using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigantha.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Timelines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: true),
                    End = table.Column<DateTime>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timelines", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Timelines_Name",
                table: "Timelines",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timelines");
        }
    }
}
