using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalScheduler.DataAccess.Migrations
{
    public partial class BackToOfficeReloaded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Conclusions",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "Tlyaf2EqL+7dx4Nta9jUEfB/xJhoDc52FOZWioiQH8soZGQyf6/kqfu+dogV1Gn3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Conclusions",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "KoNqOlN/YuK1p32RuVuFlbcm6GJE4ENFfAT2VAv6X3AOa9c2UE5suTYoCCOvT8ze");
        }
    }
}
