using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroEngine.Migrations
{
    /// <inheritdoc />
    public partial class CodelistTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Codelist",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeGroup = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    CodeId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(100)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codelist", x => x.Id);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Codelist");
        }
    }
}
