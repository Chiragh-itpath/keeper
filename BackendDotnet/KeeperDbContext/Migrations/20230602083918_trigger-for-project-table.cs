using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeeperDbContext.Migrations
{
    public partial class triggerforprojecttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE TRIGGER trgProjectDelete
                ON Projects
                INSTEAD OF DELETE
                AS
                BEGIN
                    UPDATE Projects
                    SET IsDeleted = 1
                    WHERE Id IN (SELECT Id FROM deleted)
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trgProjectDelete");
        }
    }
}
