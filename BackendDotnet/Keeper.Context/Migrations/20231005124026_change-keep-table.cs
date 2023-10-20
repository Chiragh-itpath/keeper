using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keeper.Context.Migrations
{
    public partial class changekeeptable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Keeps",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Keeps",
                newName: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Keeps_CreatedById",
                table: "Keeps",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Keeps_UpdatedById",
                table: "Keeps",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Keeps_Users_CreatedById",
                table: "Keeps",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Keeps_Users_UpdatedById",
                table: "Keeps",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keeps_Users_CreatedById",
                table: "Keeps");

            migrationBuilder.DropForeignKey(
                name: "FK_Keeps_Users_UpdatedById",
                table: "Keeps");

            migrationBuilder.DropIndex(
                name: "IX_Keeps_CreatedById",
                table: "Keeps");

            migrationBuilder.DropIndex(
                name: "IX_Keeps_UpdatedById",
                table: "Keeps");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                table: "Keeps",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Keeps",
                newName: "CreatedBy");
        }
    }
}
