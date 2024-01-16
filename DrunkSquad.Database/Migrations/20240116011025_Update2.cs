using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrunkSquad.Database.Migrations {
    /// <inheritdoc />
    public partial class Update2 : Migration {
        /// <inheritdoc />
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey (
                name: "FK_Factioninfo_Ranking_RankID",
                table: "Factioninfo");

            migrationBuilder.DropTable (
                name: "Ranking");

            migrationBuilder.DropTable (
                name: "Basic");

            migrationBuilder.DropIndex (
                name: "IX_Factioninfo_RankID",
                table: "Factioninfo");

            migrationBuilder.DropColumn (
                name: "RankID",
                table: "Factioninfo");
        }

        /// <inheritdoc />
        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<int> (
                name: "RankID",
                table: "Factioninfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable (
                name: "Basic",
                columns: table => new {
                    ID = table.Column<int> (type: "int", nullable: false)
                        .Annotation ("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int> (type: "int", nullable: false),
                    BestChain = table.Column<int> (type: "int", nullable: false),
                    Capacity = table.Column<int> (type: "int", nullable: false),
                    ColeaderID = table.Column<int> (type: "int", nullable: false),
                    FactionID = table.Column<int> (type: "int", nullable: false),
                    LeaderID = table.Column<int> (type: "int", nullable: false),
                    Name = table.Column<string> (type: "nvarchar(max)", nullable: true),
                    Respect = table.Column<int> (type: "int", nullable: false),
                    Tag = table.Column<string> (type: "nvarchar(max)", nullable: true),
                    TagImage = table.Column<string> (type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey ("PK_Basic", x => x.ID);
                });

            migrationBuilder.CreateTable (
                name: "Ranking",
                columns: table => new {
                    ID = table.Column<int> (type: "int", nullable: false)
                        .Annotation ("SqlServer:Identity", "1, 1"),
                    FactionID = table.Column<int> (type: "int", nullable: true),
                    Division = table.Column<int> (type: "int", nullable: false),
                    Level = table.Column<int> (type: "int", nullable: false),
                    Position = table.Column<int> (type: "int", nullable: false),
                    Rank = table.Column<int> (type: "int", nullable: false),
                    RankingID = table.Column<int> (type: "int", nullable: false),
                    Wins = table.Column<int> (type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey ("PK_Ranking", x => x.ID);
                    table.ForeignKey (
                        name: "FK_Ranking_Basic_FactionID",
                        column: x => x.FactionID,
                        principalTable: "Basic",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex (
                name: "IX_Factioninfo_RankID",
                table: "Factioninfo",
                column: "RankID");

            migrationBuilder.CreateIndex (
                name: "IX_Ranking_FactionID",
                table: "Ranking",
                column: "FactionID");

            migrationBuilder.AddForeignKey (
                name: "FK_Factioninfo_Ranking_RankID",
                table: "Factioninfo",
                column: "RankID",
                principalTable: "Ranking",
                principalColumn: "ID");
        }
    }
}
