using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalScheduler.DataAccess.Migrations
{
    public partial class _7thMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Type" },
                values: new object[] { 3, "Other" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
