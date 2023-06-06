using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeeperDbContext.Migrations
{
    public partial class tagrefinkeep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TagId",
                table: "Keeps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Keeps_TagId",
                table: "Keeps",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Keeps_Tags_TagId",
                table: "Keeps",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keeps_Tags_TagId",
                table: "Keeps");

            migrationBuilder.DropIndex(
                name: "IX_Keeps_TagId",
                table: "Keeps");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Keeps");
        }
    }
}
