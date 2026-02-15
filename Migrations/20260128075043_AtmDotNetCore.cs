using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATMDotNetCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class AtmDotNetCore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblUsersMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccNo = table.Column<int>(type: "int", nullable: false),
                    ActPin = table.Column<int>(type: "int", nullable: false),
                    ActName = table.Column<int>(type: "int", nullable: false),
                    AccIsActive = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUsersMaster", x => x.Id);
                });
        }
        
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblUsersMaster");
        }
    }
}
