using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroEngine.Migrations
{
    /// <inheritdoc />
    public partial class AddTableEmailConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AbsenceFormCode",
                table: "AbsenceForm",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.CreateTable(
                name: "EmailConfig",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Port = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Sender = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    EnableTLS = table.Column<bool>(type: "bit", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailConfig", x => x.ConfigId);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "EmailConfig");

            migrationBuilder.DropColumn(name: "AbsenceFormCode", table: "AbsenceForm");
        }
    }
}
