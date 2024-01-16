using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrunkSquad.Database.Migrations {
    /// <inheritdoc />
    public partial class Update4 : Migration {
        /// <inheritdoc />
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable (
                name: "CrimeParticipants");

            migrationBuilder.DropPrimaryKey (
                name: "FactionCrimeID",
                table: "Crime");

            migrationBuilder.DropColumn (
                name: "Discriminator",
                table: "Crime");

            migrationBuilder.RenameTable (
                name: "Crime",
                newName: "Crimes");

            migrationBuilder.AddColumn<string> (
                name: "Participants",
                table: "Crimes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey (
                name: "PK_Crimes",
                table: "Crimes",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.DropPrimaryKey (
                name: "PK_Crimes",
                table: "Crimes");

            migrationBuilder.DropColumn (
                name: "Participants",
                table: "Crimes");

            migrationBuilder.RenameTable (
                name: "Crimes",
                newName: "Crime");

            migrationBuilder.AddColumn<string> (
                name: "Discriminator",
                table: "Crime",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey (
                name: "FactionCrimeID",
                table: "Crime",
                column: "ID");

            migrationBuilder.CreateTable (
                name: "CrimeParticipants",
                columns: table => new {
                    ID = table.Column<int> (type: "int", nullable: false)
                        .Annotation ("SqlServer:Identity", "1, 1"),
                    CrimeID = table.Column<int> (type: "int", nullable: true),
                    ParticipantID = table.Column<int> (type: "int", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey ("PK_CrimeParticipants", x => x.ID);
                    table.ForeignKey (
                        name: "FK_CrimeParticipants_Crime_CrimeID",
                        column: x => x.CrimeID,
                        principalTable: "Crime",
                        principalColumn: "ID");
                    table.ForeignKey (
                        name: "FK_CrimeParticipants_Members_ParticipantID",
                        column: x => x.ParticipantID,
                        principalTable: "Members",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex (
                name: "IX_CrimeParticipants_CrimeID",
                table: "CrimeParticipants",
                column: "CrimeID");

            migrationBuilder.CreateIndex (
                name: "IX_CrimeParticipants_ParticipantID",
                table: "CrimeParticipants",
                column: "ParticipantID");
        }
    }
}
