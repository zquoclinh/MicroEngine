using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroEngine.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableUserAccount1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "UserAccount",
                newName: "UserCode"
            );

            migrationBuilder.RenameIndex(
                name: "IX_UserAccount_UserID",
                table: "UserAccount",
                newName: "IX_UserAccount_UserCode"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserCode",
                table: "UserAccount",
                newName: "UserID"
            );

            migrationBuilder.RenameIndex(
                name: "IX_UserAccount_UserCode",
                table: "UserAccount",
                newName: "IX_UserAccount_UserID"
            );
        }
    }
}
