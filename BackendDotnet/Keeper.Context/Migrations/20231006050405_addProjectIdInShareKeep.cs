using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keeper.Context.Migrations
{
    public partial class addProjectIdInShareKeep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Items",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Items",
                newName: "CreatedById");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "SharedKeeps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SharedKeeps_ProjectId",
                table: "SharedKeeps",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CreatedById",
                table: "Items",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UpdatedById",
                table: "Items",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_CreatedById",
                table: "Items",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_UpdatedById",
                table: "Items",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SharedKeeps_Projects_ProjectId",
                table: "SharedKeeps",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_CreatedById",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_UpdatedById",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_SharedKeeps_Projects_ProjectId",
                table: "SharedKeeps");

            migrationBuilder.DropIndex(
                name: "IX_SharedKeeps_ProjectId",
                table: "SharedKeeps");

            migrationBuilder.DropIndex(
                name: "IX_Items_CreatedById",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_UpdatedById",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "SharedKeeps");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                table: "Items",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Items",
                newName: "CreatedBy");
        }
    }
}
