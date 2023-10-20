using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keeper.Context.Migrations
{
    public partial class changecolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAcccepted",
                table: "SharedProjects",
                newName: "IsAccepted");

            migrationBuilder.RenameColumn(
                name: "IsAcccepted",
                table: "SharedKeeps",
                newName: "IsAccepted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAccepted",
                table: "SharedProjects",
                newName: "IsAcccepted");

            migrationBuilder.RenameColumn(
                name: "IsAccepted",
                table: "SharedKeeps",
                newName: "IsAcccepted");
        }
    }
}
