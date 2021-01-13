using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalScheduler.DataAccess.Migrations
{
    public partial class _4thMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "RoleId",
                table: "Users",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
