using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrunkSquad.Database.Migrations
{
    /// <inheritdoc />
    public partial class Update012524_0307 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Marriages_MarriageID",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_MarriageID",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "MarriageID",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "PositionID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PositionID",
                table: "Users",
                column: "PositionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Positions_PositionID",
                table: "Users",
                column: "PositionID",
                principalTable: "Positions",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Positions_PositionID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PositionID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PositionID",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "MarriageID",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_MarriageID",
                table: "Profiles",
                column: "MarriageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Marriages_MarriageID",
                table: "Profiles",
                column: "MarriageID",
                principalTable: "Marriages",
                principalColumn: "ID");
        }
    }
}
