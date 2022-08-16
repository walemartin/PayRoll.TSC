using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayRoll.TSC.Data.Migrations
{
    public partial class pay2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BankBranch",
                newName: "Bank");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TitleID = table.Column<int>(type: "int", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    MaritalStatusID = table.Column<int>(type: "int", nullable: true),
                    StateOfOriginID = table.Column<int>(type: "int", nullable: true),
                    NationalityID = table.Column<int>(type: "int", nullable: true),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_MaritalStatus_MaritalStatusID",
                        column: x => x.MaritalStatusID,
                        principalTable: "MaritalStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Nationality_NationalityID",
                        column: x => x.NationalityID,
                        principalTable: "Nationality",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_StateOfOrigin_StateOfOriginID",
                        column: x => x.StateOfOriginID,
                        principalTable: "StateOfOrigin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Title_TitleID",
                        column: x => x.TitleID,
                        principalTable: "Title",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaveType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Leave = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoOfDaysAnnually = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NavigationMenuViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsExternal = table.Column<bool>(type: "bit", nullable: false),
                    ExternalUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Permitted = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationMenuViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NHF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<int>(type: "int", nullable: true),
                    NHFpercentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pension",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<int>(type: "int", nullable: true),
                    PensionPercentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pension", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeType = table.Column<int>(type: "int", nullable: true),
                    JobTitleID = table.Column<int>(type: "int", nullable: true),
                    BankBranchID = table.Column<int>(type: "int", nullable: true),
                    Currency = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PensionID = table.Column<int>(type: "int", nullable: true),
                    NHFID = table.Column<int>(type: "int", nullable: true),
                    NHISMonthlyAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LeaveTypeID = table.Column<int>(type: "int", nullable: true),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkData_BankBranch_BankBranchID",
                        column: x => x.BankBranchID,
                        principalTable: "BankBranch",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkData_JobTitle_JobTitleID",
                        column: x => x.JobTitleID,
                        principalTable: "JobTitle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkData_LeaveType_LeaveTypeID",
                        column: x => x.LeaveTypeID,
                        principalTable: "LeaveType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkData_NHF_NHFID",
                        column: x => x.NHFID,
                        principalTable: "NHF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkData_Pension_PensionID",
                        column: x => x.PensionID,
                        principalTable: "Pension",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MaritalStatusID",
                table: "Employees",
                column: "MaritalStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalityID",
                table: "Employees",
                column: "NationalityID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StateOfOriginID",
                table: "Employees",
                column: "StateOfOriginID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TitleID",
                table: "Employees",
                column: "TitleID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkData_BankBranchID",
                table: "WorkData",
                column: "BankBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkData_JobTitleID",
                table: "WorkData",
                column: "JobTitleID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkData_LeaveTypeID",
                table: "WorkData",
                column: "LeaveTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkData_NHFID",
                table: "WorkData",
                column: "NHFID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkData_PensionID",
                table: "WorkData",
                column: "PensionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "NavigationMenuViewModel");

            migrationBuilder.DropTable(
                name: "WorkData");

            migrationBuilder.DropTable(
                name: "LeaveType");

            migrationBuilder.DropTable(
                name: "NHF");

            migrationBuilder.DropTable(
                name: "Pension");

            migrationBuilder.RenameColumn(
                name: "Bank",
                table: "BankBranch",
                newName: "Name");
        }
    }
}
