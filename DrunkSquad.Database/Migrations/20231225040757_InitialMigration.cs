using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DrunkSquad.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerID = table.Column<int>(type: "integer", nullable: false),
                    Current = table.Column<int>(type: "integer", nullable: false),
                    Fulltime = table.Column<int>(type: "integer", nullable: false),
                    Increment = table.Column<int>(type: "integer", nullable: false),
                    Interval = table.Column<int>(type: "integer", nullable: false),
                    Maximum = table.Column<int>(type: "integer", nullable: false),
                    Ticktime = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bars", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Crimes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FactionID = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Initiated = table.Column<bool>(type: "boolean", nullable: false),
                    InitiatedBy = table.Column<int>(type: "integer", nullable: false),
                    MoneyGain = table.Column<int>(type: "integer", nullable: false),
                    PlannedBy = table.Column<int>(type: "integer", nullable: false),
                    RespectGain = table.Column<int>(type: "integer", nullable: false),
                    Success = table.Column<bool>(type: "boolean", nullable: false),
                    TimeComplete = table.Column<long>(type: "bigint", nullable: false),
                    TimeLeft = table.Column<int>(type: "integer", nullable: false),
                    TimeReady = table.Column<long>(type: "bigint", nullable: false),
                    TimeCreated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crimes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FactionStubs",
                columns: table => new
                {
                    FactionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DaysInFaction = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FactionTag = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactionStubs", x => x.FactionID);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerID = table.Column<int>(type: "integer", nullable: false),
                    CompanyID = table.Column<int>(type: "integer", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LastActions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerID = table.Column<int>(type: "integer", nullable: false),
                    Relative = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastActions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoginDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApiKey = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Marriages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerID = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    SpouseID = table.Column<int>(type: "integer", nullable: false),
                    SpouseName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marriages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerID = table.Column<int>(type: "integer", nullable: false),
                    HospitalTimestamp = table.Column<long>(type: "bigint", nullable: false),
                    JailTimestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerID = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Until = table.Column<long>(type: "bigint", nullable: false),
                    CrimeID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Statuses_Crimes_CrimeID",
                        column: x => x.CrimeID,
                        principalTable: "Crimes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FactionID = table.Column<int>(type: "integer", nullable: false),
                    DaysInFaction = table.Column<int>(type: "integer", nullable: false),
                    LastActionID = table.Column<int>(type: "integer", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    StatusID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Members_LastActions_LastActionID",
                        column: x => x.LastActionID,
                        principalTable: "LastActions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Members_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoginDetailsID = table.Column<int>(type: "integer", nullable: true),
                    MembershipInfoID = table.Column<int>(type: "integer", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Awards = table.Column<int>(type: "integer", nullable: false),
                    Donator = table.Column<bool>(type: "boolean", nullable: false),
                    Enemies = table.Column<int>(type: "integer", nullable: false),
                    FactionID = table.Column<int>(type: "integer", nullable: true),
                    ForumPosts = table.Column<int>(type: "integer", nullable: false),
                    Friends = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Honor = table.Column<int>(type: "integer", nullable: false),
                    JobID = table.Column<int>(type: "integer", nullable: true),
                    Karma = table.Column<int>(type: "integer", nullable: false),
                    LastActionID = table.Column<int>(type: "integer", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    LifeID = table.Column<int>(type: "integer", nullable: true),
                    MarriageID = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Rank = table.Column<string>(type: "text", nullable: true),
                    Revivable = table.Column<bool>(type: "boolean", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Signup = table.Column<string>(type: "text", nullable: true),
                    StatesID = table.Column<int>(type: "integer", nullable: true),
                    StatusID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Bars_LifeID",
                        column: x => x.LifeID,
                        principalTable: "Bars",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_FactionStubs_FactionID",
                        column: x => x.FactionID,
                        principalTable: "FactionStubs",
                        principalColumn: "FactionID");
                    table.ForeignKey(
                        name: "FK_Users_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_LastActions_LastActionID",
                        column: x => x.LastActionID,
                        principalTable: "LastActions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_LoginDetails_LoginDetailsID",
                        column: x => x.LoginDetailsID,
                        principalTable: "LoginDetails",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_Marriages_MarriageID",
                        column: x => x.MarriageID,
                        principalTable: "Marriages",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_Members_MembershipInfoID",
                        column: x => x.MembershipInfoID,
                        principalTable: "Members",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_PlayerStates_StatesID",
                        column: x => x.StatesID,
                        principalTable: "PlayerStates",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_LastActionID",
                table: "Members",
                column: "LastActionID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_StatusID",
                table: "Members",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_CrimeID",
                table: "Statuses",
                column: "CrimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FactionID",
                table: "Users",
                column: "FactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_JobID",
                table: "Users",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LastActionID",
                table: "Users",
                column: "LastActionID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LifeID",
                table: "Users",
                column: "LifeID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoginDetailsID",
                table: "Users",
                column: "LoginDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MarriageID",
                table: "Users",
                column: "MarriageID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MembershipInfoID",
                table: "Users",
                column: "MembershipInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatesID",
                table: "Users",
                column: "StatesID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusID",
                table: "Users",
                column: "StatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Bars");

            migrationBuilder.DropTable(
                name: "FactionStubs");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "LoginDetails");

            migrationBuilder.DropTable(
                name: "Marriages");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "PlayerStates");

            migrationBuilder.DropTable(
                name: "LastActions");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Crimes");
        }
    }
}
