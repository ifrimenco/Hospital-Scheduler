using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalScheduler.DataAccess.Migrations
{
    public partial class Remote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "gmFSU1/x+nJmjO9nRAZeuNxWbxfn+YeeTEmEe3zcb6whLT4OxXzsdCUbGmn+uV4o");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100,
                column: "PasswordHash",
                value: "5aZsAChjOr0cta1foeeXw0+cYV7yE+5N0m+uJK9pFGe8vpPcXW4J2cQHkrScSnor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "VI7lBqGVLbcPg4bSViydLyuujJI7iwQn8x4d9CGm+k7U4TXDj5AUdQqC+yy7nGVF");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100,
                column: "PasswordHash",
                value: "PT16g/FEewtQKkulIsxAy/CuaCu+vfHKkGMGDDXUKmTyxVxyuvlLVOmHO0Jr2s4N");
        }
    }
}
