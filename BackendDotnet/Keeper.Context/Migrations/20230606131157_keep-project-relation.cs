using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keeper.Context.Migrations
{
    public partial class keepprojectrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Keeps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Keeps_ProjectId",
                table: "Keeps",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Keeps_Projects_ProjectId",
                table: "Keeps",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keeps_Projects_ProjectId",
                table: "Keeps");

            migrationBuilder.DropIndex(
                name: "IX_Keeps_ProjectId",
                table: "Keeps");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Keeps");
        }
    }
}
