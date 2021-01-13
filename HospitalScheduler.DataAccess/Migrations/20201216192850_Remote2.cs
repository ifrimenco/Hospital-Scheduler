using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalScheduler.DataAccess.Migrations
{
    public partial class Remote2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "qYZb9rFTRHsv+0hs9O6DvwYKNVDazsArBz3b5HYMlvggI12Nu2kCBHz4p6mMKuFh");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100,
                column: "PasswordHash",
                value: "Tnx0949WaVn/MVsqdq+k49IkQSM6hjWtP8gEsqmDP8aYTD0knO4fbi+/VRVZoTzd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
