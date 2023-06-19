using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keeper.Context.Migrations
{
    public partial class itemfilestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "FileModelItemModel",
                columns: table => new
                {
                    FilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileModelItemModel", x => new { x.FilesId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_FileModelItemModel_Files_FilesId",
                        column: x => x.FilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileModelItemModel_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileModelItemModel_ItemsId",
                table: "FileModelItemModel",
                column: "ItemsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileModelItemModel");

            migrationBuilder.AddColumn<Guid>(
                name: "FileId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
