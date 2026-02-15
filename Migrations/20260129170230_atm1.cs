using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATMDotNetCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class atm1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblAtmTransaction",
                columns: table => new
                {
                    TransacId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccNo = table.Column<int>(type: "int", nullable: false),
                    DateOfTrans = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransacNo = table.Column<int>(type: "int", nullable: false),
                    TransacAmt = table.Column<double>(type: "float", nullable: false),
                    TransacType = table.Column<int>(type: "int", nullable: false),
                    TransferToAccNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAtmTransaction", x => x.TransacId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblAtmTransaction");
        }
    }
}
