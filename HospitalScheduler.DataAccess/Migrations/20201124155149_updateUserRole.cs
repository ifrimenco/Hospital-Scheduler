using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalScheduler.DataAccess.Migrations
{
    public partial class updateUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "VusaySeniAo9u7xJBZ7VwdqK3e1QVHRTLrIyTiP2alirehd2e+zJ9hp5cLb986AD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "wM24YcZlBMQfRDMoMqXLc804CljeD5s/qKVEYNIa8HERF/M3I1BzPHIXS2p2/mvK");
        }
    }
}
