using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Services.AccountAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccountSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Number", "OwnerId" },
                values: new object[] { "1FFF4567890", 18726482 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Number", "OwnerId" },
                values: new object[] { "0987GTF321", 483258 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Number", "OwnerId" },
                values: new object[] { "1234567890", 1 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Number", "OwnerId" },
                values: new object[] { "0987654321", 2 });
        }
    }
}
