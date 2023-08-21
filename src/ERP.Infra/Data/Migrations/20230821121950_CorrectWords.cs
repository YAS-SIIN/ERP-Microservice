using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrectWords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImaghePath",
                schema: "EMP",
                table: "Employee",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "EmpoloyeeNo",
                schema: "EMP",
                table: "Employee",
                newName: "EmployeeNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                schema: "EMP",
                table: "Employee",
                newName: "ImaghePath");

            migrationBuilder.RenameColumn(
                name: "EmployeeNo",
                schema: "EMP",
                table: "Employee",
                newName: "EmpoloyeeNo");
        }
    }
}
