using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroEngine.Migrations
{
    /// <inheritdoc />
    public partial class DataSettingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Setting",
                columns: new[] { "Name", "Value" },
                values: new object[]
                {
                    "WebApiSetting.SecretKey",
                    "lNMJ8FzDjL15jalPwAXcR3RV46EQsO5N",
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Setting",
                keyColumn: "Name",
                keyValue: "WebApiSetting.SecretKey"
            );
        }
    }
}
