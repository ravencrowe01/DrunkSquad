using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrunkSquad.Database.Migrations
{
    /// <inheritdoc />
    public partial class PositionUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bar");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "LoginDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApiKey",
                table: "LoginDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Default = table.Column<int>(type: "int", nullable: false),
                    CanUseMedicalItem = table.Column<int>(type: "int", nullable: false),
                    CanUseBoosterItem = table.Column<int>(type: "int", nullable: false),
                    CanUseDrugItem = table.Column<int>(type: "int", nullable: false),
                    CanUseEnergyRefill = table.Column<int>(type: "int", nullable: false),
                    CanUseNerveRefill = table.Column<int>(type: "int", nullable: false),
                    CanLoanTemporaryItem = table.Column<int>(type: "int", nullable: false),
                    CanLoanWeaponAndArmory = table.Column<int>(type: "int", nullable: false),
                    CanRetrieveLoanedArmory = table.Column<int>(type: "int", nullable: false),
                    CanPlanAndInitiateOrganisedCrime = table.Column<int>(type: "int", nullable: false),
                    CanAccessFactionApi = table.Column<int>(type: "int", nullable: false),
                    CanGiveItem = table.Column<int>(type: "int", nullable: false),
                    CanGiveMoney = table.Column<int>(type: "int", nullable: false),
                    CanGivePoints = table.Column<int>(type: "int", nullable: false),
                    CanManageForum = table.Column<int>(type: "int", nullable: false),
                    CanManageApplications = table.Column<int>(type: "int", nullable: false),
                    CanKickMembers = table.Column<int>(type: "int", nullable: false),
                    CanAdjustMemberBalance = table.Column<int>(type: "int", nullable: false),
                    CanManageWars = table.Column<int>(type: "int", nullable: false),
                    CanManageUpgrades = table.Column<int>(type: "int", nullable: false),
                    CanSendNewsletter = table.Column<int>(type: "int", nullable: false),
                    CanChangeAnnouncement = table.Column<int>(type: "int", nullable: false),
                    CanChangeDescription = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PositionMetas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionID = table.Column<int>(type: "int", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionMetas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PositionMetas_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PositionMetas_PositionID",
                table: "PositionMetas",
                column: "PositionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionMetas");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "LoginDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApiKey",
                table: "LoginDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Bar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarID = table.Column<int>(type: "int", nullable: false),
                    Current = table.Column<int>(type: "int", nullable: false),
                    Fulltime = table.Column<int>(type: "int", nullable: false),
                    Increment = table.Column<int>(type: "int", nullable: false),
                    Interval = table.Column<int>(type: "int", nullable: false),
                    Maximum = table.Column<int>(type: "int", nullable: false),
                    ProfileID = table.Column<int>(type: "int", nullable: true),
                    Ticktime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bar_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bar_ProfileID",
                table: "Bar",
                column: "ProfileID");
        }
    }
}
