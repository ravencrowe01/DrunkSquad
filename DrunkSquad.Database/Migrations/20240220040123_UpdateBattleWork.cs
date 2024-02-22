using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrunkSquad.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBattleWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BattleStatsID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkingStatsID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BattleStats",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BattleStatsID = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    StrengthModifier = table.Column<int>(type: "int", nullable: false),
                    DefenseModifier = table.Column<int>(type: "int", nullable: false),
                    SpeedModifier = table.Column<int>(type: "int", nullable: false),
                    DexterityModifier = table.Column<int>(type: "int", nullable: false),
                    StrengthInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefenseInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpeedInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DexterityInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleStats", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WorkingStats",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkinStatsID = table.Column<int>(type: "int", nullable: false),
                    ManualLabor = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Endurance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingStats", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_BattleStatsID",
                table: "Users",
                column: "BattleStatsID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WorkingStatsID",
                table: "Users",
                column: "WorkingStatsID");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_BattleStats_BattleStatsID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_WorkingStats_WorkingStatsID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BattleStats");

            migrationBuilder.DropTable(
                name: "WorkingStats");

            migrationBuilder.DropIndex(
                name: "IX_Users_BattleStatsID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_WorkingStatsID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BattleStatsID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WorkingStatsID",
                table: "Users");
        }
    }
}
