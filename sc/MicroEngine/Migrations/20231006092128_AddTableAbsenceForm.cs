using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroEngine.Migrations
{
    /// <inheritdoc />
    public partial class AddTableAbsenceForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbsenceForm",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    AbsenceFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AbsenceToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAbsenceDay = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    ReasonAbsence = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    AbsenceType = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PersonApprove = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceForm", x => x.Id);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "AbsenceForm");
        }
    }
}
