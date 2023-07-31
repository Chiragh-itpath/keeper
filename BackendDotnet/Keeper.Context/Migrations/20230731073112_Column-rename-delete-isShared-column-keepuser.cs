using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keeper.Context.Migrations
{
    public partial class ColumnrenamedeleteisSharedcolumnkeepuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectUserModels",
                table: "ProjectUserModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_keepUserModels",
                table: "keepUserModels");

            migrationBuilder.DropColumn(
                name: "IsShared",
                table: "keepUserModels");

            migrationBuilder.RenameTable(
                name: "ProjectUserModels",
                newName: "ProjectUser");

            migrationBuilder.RenameTable(
                name: "keepUserModels",
                newName: "keepUser");

            migrationBuilder.RenameColumn(
                name: "IsShared",
                table: "ProjectUser",
                newName: "HasFullAccess");

            migrationBuilder.AlterColumn<Guid>(
                name: "KeepId",
                table: "keepUser",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectUser",
                table: "ProjectUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_keepUser",
                table: "keepUser",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectUser",
                table: "ProjectUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_keepUser",
                table: "keepUser");

            migrationBuilder.RenameTable(
                name: "ProjectUser",
                newName: "ProjectUserModels");

            migrationBuilder.RenameTable(
                name: "keepUser",
                newName: "keepUserModels");

            migrationBuilder.RenameColumn(
                name: "HasFullAccess",
                table: "ProjectUserModels",
                newName: "IsShared");

            migrationBuilder.AlterColumn<Guid>(
                name: "KeepId",
                table: "keepUserModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsShared",
                table: "keepUserModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectUserModels",
                table: "ProjectUserModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_keepUserModels",
                table: "keepUserModels",
                column: "Id");
        }
    }
}
