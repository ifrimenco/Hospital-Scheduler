using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalScheduler.DataAccess.Migrations
{
    public partial class BackToOffice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "KoNqOlN/YuK1p32RuVuFlbcm6GJE4ENFfAT2VAv6X3AOa9c2UE5suTYoCCOvT8ze");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "jlFaOIfI8LEXYfLa6ZzAeCzBVhtn3XJt87TxkXX+s2H6bPqlqEvnkx4PgTlu5LUq");
        }
    }
}
