using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeeperDbContext.Migrations
{
    public partial class keepusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "KeepId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Keeps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "KeepUser",
                columns: table => new
                {
                    KeepModelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeepUser", x => new { x.KeepModelsId, x.UsersID });
                    table.ForeignKey(
                        name: "FK_KeepUser_Keeps_KeepModelsId",
                        column: x => x.KeepModelsId,
                        principalTable: "Keeps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeepUser_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeepUser_UsersID",
                table: "KeepUser",
                column: "UsersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeepUser");

            migrationBuilder.DropColumn(
                name: "KeepId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Keeps");
        }
    }
}
