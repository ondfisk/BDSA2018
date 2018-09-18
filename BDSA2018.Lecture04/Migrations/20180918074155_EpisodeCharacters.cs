using Microsoft.EntityFrameworkCore.Migrations;

namespace BDSA2018.Lecture04.Migrations
{
    public partial class EpisodeCharacters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Number = table.Column<string>(maxLength: 10, nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeCharacters",
                columns: table => new
                {
                    EpisodeNumber = table.Column<string>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeCharacters", x => new { x.EpisodeNumber, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_EpisodeCharacters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeCharacters_Episodes_EpisodeNumber",
                        column: x => x.EpisodeNumber,
                        principalTable: "Episodes",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeCharacters_CharacterId",
                table: "EpisodeCharacters",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodeCharacters");

            migrationBuilder.DropTable(
                name: "Episodes");
        }
    }
}
