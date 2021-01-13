using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalScheduler.DataAccess.Migrations
{
    public partial class userMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "n2oxWexcouGvxwOEBtfub0nEMf1XPiNusjw7w+UNExrrfaXzk8Ge3JgwQ4/xuiOt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "VusaySeniAo9u7xJBZ7VwdqK3e1QVHRTLrIyTiP2alirehd2e+zJ9hp5cLb986AD");
        }
    }
}
