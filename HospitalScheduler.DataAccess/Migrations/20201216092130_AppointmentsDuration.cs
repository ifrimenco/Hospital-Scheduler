using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalScheduler.DataAccess.Migrations
{
    public partial class AppointmentsDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "OdQpeQsYzj3RUoAL8ML1dtknt2XrDFXWtGa/Of59KegqmCgz+DqU4uWRb5P+r/Ar");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNP", "Email", "FirstName", "GenderId", "LastName", "PasswordHash", "SpecializationId" },
                values: new object[] { 100, "Confidential", "Confidential", "Confidential", 3, "", "RDKspFPAfF6YrH9pm/C4LNL6jdifovGjyUhaBd8d/exdK6o4ixSOyfBjjjomxnwq", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "bmmKlfbfQuKzresf2b2szD/BaRujzmAIxXXT6+S52oiyG7L3CWZdnrEzQ7Vvr+ZW");
        }
    }
}
