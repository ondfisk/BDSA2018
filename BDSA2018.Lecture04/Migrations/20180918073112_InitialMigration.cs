using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BDSA2018.Lecture04.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActorId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Species = table.Column<string>(maxLength: 50, nullable: false),
                    Planet = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Billy West" },
                    { 2, "Katey Sagal" },
                    { 3, "John DiMaggio" },
                    { 4, "Lauren Tom" },
                    { 5, "Phil LaMarr" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "Planet", "Species" },
                values: new object[,]
                {
                    { 1, 1, "Philip J. Fry", "Earth", "Human" },
                    { 4, 1, "John A. Zoidberg", "Decapod 10", "Decapodian" },
                    { 7, 1, "Hubert J. Farnsworth", "Earth", "Human" },
                    { 2, 2, "Leela Turanga", "Earth", "Mutant, Human" },
                    { 3, 3, "Bender Bending Rodrique", "Earth", "Robot" },
                    { 5, 4, "Amy Wong", "Mars", "Human" },
                    { 6, 5, "Hermes Conrad", "Earth", "Human" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ActorId",
                table: "Characters",
                column: "ActorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Actors");
        }
    }
}
