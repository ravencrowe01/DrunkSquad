using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrunkSquad.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Basic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BestChain = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    ColeaderID = table.Column<int>(type: "int", nullable: false),
                    FactionID = table.Column<int>(type: "int", nullable: false),
                    LeaderID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Respect = table.Column<int>(type: "int", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basic", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Crime",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrimeID = table.Column<int>(type: "int", nullable: false),
                    CrimeType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Initiated = table.Column<bool>(type: "bit", nullable: false),
                    InitiatedBy = table.Column<int>(type: "int", nullable: false),
                    MoneyGain = table.Column<int>(type: "int", nullable: false),
                    PlannedBy = table.Column<int>(type: "int", nullable: false),
                    RespectGain = table.Column<int>(type: "int", nullable: false),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    TimeComplete = table.Column<long>(type: "bigint", nullable: false),
                    TimeLeft = table.Column<int>(type: "int", nullable: false),
                    TimeReady = table.Column<long>(type: "bigint", nullable: false),
                    TimeStarted = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FactionCrimeID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LastActions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastActionID = table.Column<int>(type: "int", nullable: false),
                    Relative = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Marriages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarriageID = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    SpouseID = table.Column<int>(type: "int", nullable: false),
                    SpouseName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marriages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerStatesID = table.Column<int>(type: "int", nullable: false),
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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Until = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Factioninfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasicID = table.Column<int>(type: "int", nullable: true),
                    FactionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factioninfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Factioninfo_Basic_BasicID",
                        column: x => x.BasicID,
                        principalTable: "Basic",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Awards = table.Column<int>(type: "int", nullable: false),
                    Donator = table.Column<bool>(type: "bit", nullable: false),
                    Enemies = table.Column<int>(type: "int", nullable: false),
                    ForumPosts = table.Column<int>(type: "int", nullable: false),
                    Friends = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Honor = table.Column<int>(type: "int", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: true),
                    Karma = table.Column<int>(type: "int", nullable: false),
                    LastActionID = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    MarriageID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileID = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revivable = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatesID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Profiles_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Profiles_LastActions_LastActionID",
                        column: x => x.LastActionID,
                        principalTable: "LastActions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Profiles_Marriages_MarriageID",
                        column: x => x.MarriageID,
                        principalTable: "Marriages",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Profiles_PlayerStates_StatesID",
                        column: x => x.StatesID,
                        principalTable: "PlayerStates",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Profiles_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    FactionID = table.Column<int>(type: "int", nullable: false),
                    DaysInFaction = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactionInfoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Members_Factioninfo_FactionInfoID",
                        column: x => x.FactionInfoID,
                        principalTable: "Factioninfo",
                        principalColumn: "ID");
                });

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
                    Ticktime = table.Column<int>(type: "int", nullable: false),
                    ProfileID = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ProfileID = table.Column<int>(type: "int", nullable: true),
                    LoginDetailsID = table.Column<int>(type: "int", nullable: true),
                    WebsiteRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_LoginDetails_LoginDetailsID",
                        column: x => x.LoginDetailsID,
                        principalTable: "LoginDetails",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CrimeParticipants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrimeID = table.Column<int>(type: "int", nullable: true),
                    ParticipantID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeParticipants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CrimeParticipants_Crime_CrimeID",
                        column: x => x.CrimeID,
                        principalTable: "Crime",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CrimeParticipants_Members_ParticipantID",
                        column: x => x.ParticipantID,
                        principalTable: "Members",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bar_ProfileID",
                table: "Bar",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_CrimeParticipants_CrimeID",
                table: "CrimeParticipants",
                column: "CrimeID");

            migrationBuilder.CreateIndex(
                name: "IX_CrimeParticipants_ParticipantID",
                table: "CrimeParticipants",
                column: "ParticipantID");

            migrationBuilder.CreateIndex(
                name: "IX_Factioninfo_BasicID",
                table: "Factioninfo",
                column: "BasicID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_FactionInfoID",
                table: "Members",
                column: "FactionInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_JobID",
                table: "Profiles",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_LastActionID",
                table: "Profiles",
                column: "LastActionID");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_MarriageID",
                table: "Profiles",
                column: "MarriageID");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_StatesID",
                table: "Profiles",
                column: "StatesID");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_StatusID",
                table: "Profiles",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoginDetailsID",
                table: "Users",
                column: "LoginDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileID",
                table: "Users",
                column: "ProfileID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bar");

            migrationBuilder.DropTable(
                name: "CrimeParticipants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Crime");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "LoginDetails");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Factioninfo");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "LastActions");

            migrationBuilder.DropTable(
                name: "Marriages");

            migrationBuilder.DropTable(
                name: "PlayerStates");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Basic");
        }
    }
}
