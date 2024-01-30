using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrunkSquad.Database.Migrations
{
    /// <inheritdoc />
    public partial class Update013024_0000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrimeExperence_Members_MemberID",
                table: "CrimeExperence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrimeExperence",
                table: "CrimeExperence");

            migrationBuilder.RenameTable(
                name: "CrimeExperence",
                newName: "CrimeExperience");

            migrationBuilder.RenameIndex(
                name: "IX_CrimeExperence_MemberID",
                table: "CrimeExperience",
                newName: "IX_CrimeExperience_MemberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrimeExperience",
                table: "CrimeExperience",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CrimeExperience_Members_MemberID",
                table: "CrimeExperience",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrimeExperience_Members_MemberID",
                table: "CrimeExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrimeExperience",
                table: "CrimeExperience");

            migrationBuilder.RenameTable(
                name: "CrimeExperience",
                newName: "CrimeExperence");

            migrationBuilder.RenameIndex(
                name: "IX_CrimeExperience_MemberID",
                table: "CrimeExperence",
                newName: "IX_CrimeExperence_MemberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrimeExperence",
                table: "CrimeExperence",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CrimeExperence_Members_MemberID",
                table: "CrimeExperence",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "ID");
        }
    }
}
