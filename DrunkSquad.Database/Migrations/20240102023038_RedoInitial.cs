using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DrunkSquad.Database.Migrations
{
    /// <inheritdoc />
    public partial class RedoInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    BarID = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("BarID", x => x.BarID);
                });

            migrationBuilder.CreateTable(
                name: "Crimes",
                columns: table => new
                {
                    CrimeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CrimeType = table.Column<int>(type: "integer", nullable: false),
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
                    TimeStarted = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FactionCrimeID", x => x.CrimeID);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("JobID", x => x.JobID);
                });

            migrationBuilder.CreateTable(
                name: "LastActions",
                columns: table => new
                {
                    LastActionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerID = table.Column<int>(type: "integer", nullable: false),
                    Relative = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("LastActionID", x => x.LastActionID);
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
                    MarriageID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerID = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    SpouseID = table.Column<int>(type: "integer", nullable: false),
                    SpouseName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MarriageID", x => x.MarriageID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStates",
                columns: table => new
                {
                    PlayerStatesID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerID = table.Column<int>(type: "integer", nullable: false),
                    HospitalTimestamp = table.Column<long>(type: "bigint", nullable: false),
                    JailTimestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PlayerStatesID", x => x.PlayerStatesID);
                });

            migrationBuilder.CreateTable(
                name: "Ranking",
                columns: table => new
                {
                    RankingID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FactionID = table.Column<int>(type: "integer", nullable: false),
                    Division = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Wins = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranking", x => x.RankingID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerID = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Until = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ProfiStatusIDleID", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Factioninfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    BestChain = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Coleader = table.Column<int>(type: "integer", nullable: false),
                    Leader = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    RankingID = table.Column<int>(type: "integer", nullable: true),
                    Respect = table.Column<int>(type: "integer", nullable: false),
                    Tag = table.Column<string>(type: "text", nullable: true),
                    TagImage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FactionID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Factioninfo_Ranking_RankingID",
                        column: x => x.RankingID,
                        principalTable: "Ranking",
                        principalColumn: "RankingID");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FactionID = table.Column<int>(type: "integer", nullable: false),
                    DaysInFaction = table.Column<int>(type: "integer", nullable: false),
                    LastActionID = table.Column<int>(type: "integer", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    StatusID = table.Column<int>(type: "integer", nullable: true),
                    FactionInfoID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MemberID", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Members_Factioninfo_FactionInfoID",
                        column: x => x.FactionInfoID,
                        principalTable: "Factioninfo",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Members_LastActions_LastActionID",
                        column: x => x.LastActionID,
                        principalTable: "LastActions",
                        principalColumn: "LastActionID");
                    table.ForeignKey(
                        name: "FK_Members_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "StatusID");
                });

            migrationBuilder.CreateTable(
                name: "CrimeParticipants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CrimeID = table.Column<int>(type: "integer", nullable: true),
                    ParticipantMemberID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CrimeParticipantID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CrimeParticipants_Crimes_CrimeID",
                        column: x => x.CrimeID,
                        principalTable: "Crimes",
                        principalColumn: "CrimeID");
                    table.ForeignKey(
                        name: "FK_CrimeParticipants_Members_ParticipantMemberID",
                        column: x => x.ParticipantMemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ProfileID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoginDetailsID = table.Column<int>(type: "integer", nullable: true),
                    MembershipInfoMemberID = table.Column<int>(type: "integer", nullable: true),
                    WebsiteRole = table.Column<int>(type: "integer", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Awards = table.Column<int>(type: "integer", nullable: false),
                    Donator = table.Column<bool>(type: "boolean", nullable: false),
                    Enemies = table.Column<int>(type: "integer", nullable: false),
                    ForumPosts = table.Column<int>(type: "integer", nullable: false),
                    Friends = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Honor = table.Column<int>(type: "integer", nullable: false),
                    JobID = table.Column<int>(type: "integer", nullable: true),
                    Karma = table.Column<int>(type: "integer", nullable: false),
                    LastActionID = table.Column<int>(type: "integer", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    LifeBarID = table.Column<int>(type: "integer", nullable: true),
                    MarriageID = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Rank = table.Column<string>(type: "text", nullable: true),
                    Revivable = table.Column<bool>(type: "boolean", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Signup = table.Column<string>(type: "text", nullable: true),
                    StatesPlayerStatesID = table.Column<int>(type: "integer", nullable: true),
                    StatusID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ProfileID", x => x.ProfileID);
                    table.ForeignKey(
                        name: "FK_Users_Bars_LifeBarID",
                        column: x => x.LifeBarID,
                        principalTable: "Bars",
                        principalColumn: "BarID");
                    table.ForeignKey(
                        name: "FK_Users_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "JobID");
                    table.ForeignKey(
                        name: "FK_Users_LastActions_LastActionID",
                        column: x => x.LastActionID,
                        principalTable: "LastActions",
                        principalColumn: "LastActionID");
                    table.ForeignKey(
                        name: "FK_Users_LoginDetails_LoginDetailsID",
                        column: x => x.LoginDetailsID,
                        principalTable: "LoginDetails",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_Marriages_MarriageID",
                        column: x => x.MarriageID,
                        principalTable: "Marriages",
                        principalColumn: "MarriageID");
                    table.ForeignKey(
                        name: "FK_Users_Members_MembershipInfoMemberID",
                        column: x => x.MembershipInfoMemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Users_PlayerStates_StatesPlayerStatesID",
                        column: x => x.StatesPlayerStatesID,
                        principalTable: "PlayerStates",
                        principalColumn: "PlayerStatesID");
                    table.ForeignKey(
                        name: "FK_Users_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "StatusID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrimeParticipants_CrimeID",
                table: "CrimeParticipants",
                column: "CrimeID");

            migrationBuilder.CreateIndex(
                name: "IX_CrimeParticipants_ParticipantMemberID",
                table: "CrimeParticipants",
                column: "ParticipantMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Factioninfo_RankingID",
                table: "Factioninfo",
                column: "RankingID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_FactionInfoID",
                table: "Members",
                column: "FactionInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_LastActionID",
                table: "Members",
                column: "LastActionID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_StatusID",
                table: "Members",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_JobID",
                table: "Users",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LastActionID",
                table: "Users",
                column: "LastActionID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LifeBarID",
                table: "Users",
                column: "LifeBarID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoginDetailsID",
                table: "Users",
                column: "LoginDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MarriageID",
                table: "Users",
                column: "MarriageID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MembershipInfoMemberID",
                table: "Users",
                column: "MembershipInfoMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatesPlayerStatesID",
                table: "Users",
                column: "StatesPlayerStatesID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusID",
                table: "Users",
                column: "StatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrimeParticipants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Crimes");

            migrationBuilder.DropTable(
                name: "Bars");

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
                name: "Factioninfo");

            migrationBuilder.DropTable(
                name: "LastActions");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Ranking");
        }
    }
}
