using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayRoll.TSC.Data.Migrations
{
    public partial class UiController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveAllowance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveAllowance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NextOfKin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryBreakdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasicPercentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryBreakdown", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LeaveDaysAvailable = table.Column<byte>(type: "tinyint", nullable: false),
                    LeaveStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoOfDays = table.Column<byte>(type: "tinyint", nullable: false),
                    LeaveAllowanceID = table.Column<int>(type: "int", nullable: true),
                    AllowanceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReasonForLeave = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequest_LeaveAllowance_LeaveAllowanceID",
                        column: x => x.LeaveAllowanceID,
                        principalTable: "LeaveAllowance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_LeaveAllowanceID",
                table: "LeaveRequest",
                column: "LeaveAllowanceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequest");

            migrationBuilder.DropTable(
                name: "NextOfKin");

            migrationBuilder.DropTable(
                name: "SalaryBreakdown");

            migrationBuilder.DropTable(
                name: "LeaveAllowance");
        }
    }
}
