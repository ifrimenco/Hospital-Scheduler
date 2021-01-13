using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalScheduler.DataAccess.Migrations
{
    public partial class Remote3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "RR18KlgNgNnZ2wya2rU0Gc0tw/6AlloHN+jItlDIne2s3n5FFDJXgdjMclBMOQGC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100,
                column: "PasswordHash",
                value: "rzmX+3UkF2bGgy/3m1zf32saY+fbB6yzYjZQlmXQcrh/Kxodi2ApGrnjedH7x0mQ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
