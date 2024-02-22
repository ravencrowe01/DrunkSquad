using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrunkSquad.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBattleWork4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_BattleStats_BattleStatsID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_WorkingStats_WorkingStatsID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BattleStatsID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BattleStatsID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "WorkingStatsID",
                table: "Users",
                newName: "StatsID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_WorkingStatsID",
                table: "Users",
                newName: "IX_Users_StatsID");

            migrationBuilder.CreateTable(
                name: "UserStats",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileID = table.Column<int>(type: "int", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    ManualLabor = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Endurance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStats", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserStats_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStats_ProfileID",
                table: "UserStats",
                column: "ProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserStats_StatsID",
                table: "Users",
                column: "StatsID",
                principalTable: "UserStats",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserStats_StatsID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserStats");

            migrationBuilder.RenameColumn(
                name: "StatsID",
                table: "Users",
                newName: "WorkingStatsID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_StatsID",
                table: "Users",
                newName: "IX_Users_WorkingStatsID");

            migrationBuilder.AddColumn<int>(
                name: "BattleStatsID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BattleStatsID",
                table: "Users",
                column: "BattleStatsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_BattleStats_BattleStatsID",
                table: "Users",
                column: "BattleStatsID",
                principalTable: "BattleStats",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_WorkingStats_WorkingStatsID",
                table: "Users",
                column: "WorkingStatsID",
                principalTable: "WorkingStats",
                principalColumn: "ID");
        }
    }
}
