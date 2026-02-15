using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATMDotNetCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class AtmDotNetCore1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblUsersMaster",
                table: "TblUsersMaster");

            migrationBuilder.RenameTable(
                name: "TblUsersMaster",
                newName: "TblLoginMaster");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblLoginMaster",
                table: "TblLoginMaster",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblLoginMaster",
                table: "TblLoginMaster");

            migrationBuilder.RenameTable(
                name: "TblLoginMaster",
                newName: "TblUsersMaster");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblUsersMaster",
                table: "TblUsersMaster",
                column: "Id");
        }
    }
}
