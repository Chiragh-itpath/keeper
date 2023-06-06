using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeeperDbContext.Migrations
{
    public partial class tagrefinitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TagId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Items_TagId",
                table: "Items",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Tags_TagId",
                table: "Items",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Tags_TagId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_TagId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Items");
        }
    }
}
