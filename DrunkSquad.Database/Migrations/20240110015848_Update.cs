using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrunkSquad.Database.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factioninfo_Basic_BasicID",
                table: "Factioninfo");

            migrationBuilder.RenameColumn(
                name: "BasicID",
                table: "Factioninfo",
                newName: "RankID");

            migrationBuilder.RenameIndex(
                name: "IX_Factioninfo_BasicID",
                table: "Factioninfo",
                newName: "IX_Factioninfo_RankID");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Factioninfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BestChain",
                table: "Factioninfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Factioninfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ColeaderID",
                table: "Factioninfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LeaderID",
                table: "Factioninfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Factioninfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Respect",
                table: "Factioninfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Factioninfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagImage",
                table: "Factioninfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ranking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankingID = table.Column<int>(type: "int", nullable: false),
                    FactionID = table.Column<int>(type: "int", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranking", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ranking_Basic_FactionID",
                        column: x => x.FactionID,
                        principalTable: "Basic",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_FactionID",
                table: "Ranking",
                column: "FactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Factioninfo_Ranking_RankID",
                table: "Factioninfo",
                column: "RankID",
                principalTable: "Ranking",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factioninfo_Ranking_RankID",
                table: "Factioninfo");

            migrationBuilder.DropTable(
                name: "Ranking");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Factioninfo");

            migrationBuilder.DropColumn(
                name: "BestChain",
                table: "Factioninfo");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Factioninfo");

            migrationBuilder.DropColumn(
                name: "ColeaderID",
                table: "Factioninfo");

            migrationBuilder.DropColumn(
                name: "LeaderID",
                table: "Factioninfo");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Factioninfo");

            migrationBuilder.DropColumn(
                name: "Respect",
                table: "Factioninfo");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Factioninfo");

            migrationBuilder.DropColumn(
                name: "TagImage",
                table: "Factioninfo");

            migrationBuilder.RenameColumn(
                name: "RankID",
                table: "Factioninfo",
                newName: "BasicID");

            migrationBuilder.RenameIndex(
                name: "IX_Factioninfo_RankID",
                table: "Factioninfo",
                newName: "IX_Factioninfo_BasicID");

            migrationBuilder.AddForeignKey(
                name: "FK_Factioninfo_Basic_BasicID",
                table: "Factioninfo",
                column: "BasicID",
                principalTable: "Basic",
                principalColumn: "ID");
        }
    }
}
