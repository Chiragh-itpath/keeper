using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keeper.Context.Migrations
{
    public partial class userkeeprainbow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeepModelUserModel",
                columns: table => new
                {
                    KeepsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeepModelUserModel", x => new { x.KeepsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_KeepModelUserModel_Keeps_KeepsId",
                        column: x => x.KeepsId,
                        principalTable: "Keeps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeepModelUserModel_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeepModelUserModel_UsersId",
                table: "KeepModelUserModel",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeepModelUserModel");
        }
    }
}
