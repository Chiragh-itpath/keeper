using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Keeper.Context.Migrations
{
    public partial class tagrefinproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TagId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TagId",
                table: "Projects",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Tags_TagId",
                table: "Projects",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Tags_TagId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TagId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Projects");
        }
    }
}
