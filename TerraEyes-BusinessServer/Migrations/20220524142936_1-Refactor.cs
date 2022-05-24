using Microsoft.EntityFrameworkCore.Migrations;

namespace TerraEyes_BusinessServer.Migrations
{
    public partial class _1Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUserGroups");

            migrationBuilder.CreateTable(
                name: "GroupsUser",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersUserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsUser", x => new { x.GroupsId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_GroupsUser_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupsUser_UsersUserId",
                table: "GroupsUser",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupsUser");

            migrationBuilder.CreateTable(
                name: "UserUserGroups",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersUserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserGroups", x => new { x.GroupsId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_UserUserGroups_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUserGroups_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUserGroups_UsersUserId",
                table: "UserUserGroups",
                column: "UsersUserId");
        }
    }
}
