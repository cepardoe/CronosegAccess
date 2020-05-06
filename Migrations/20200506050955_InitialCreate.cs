using Microsoft.EntityFrameworkCore.Migrations;

namespace CronosegAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    IdZone = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.IdZone);
                });

            migrationBuilder.CreateTable(
                name: "Terminal",
                columns: table => new
                {
                    IdTerminal = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    ZoneIdZone = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminal", x => x.IdTerminal);
                    table.ForeignKey(
                        name: "FK_Terminal_Zone_ZoneIdZone",
                        column: x => x.ZoneIdZone,
                        principalTable: "Zone",
                        principalColumn: "IdZone",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Terminal_ZoneIdZone",
                table: "Terminal",
                column: "ZoneIdZone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Terminal");

            migrationBuilder.DropTable(
                name: "Zone");
        }
    }
}
