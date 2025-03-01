using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroEngine.Migrations
{
    /// <inheritdoc />
    public partial class AddTableCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerID",
                table: "Customer",
                column: "CustomerID"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Customer");
        }
    }
}
