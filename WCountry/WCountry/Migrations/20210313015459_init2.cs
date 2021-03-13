using Microsoft.EntityFrameworkCore.Migrations;

namespace WCountry.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WShops_WTowns_TownLocationTownName",
                table: "WShops");

            migrationBuilder.DropTable(
                name: "WTowns");

            migrationBuilder.DropIndex(
                name: "IX_WShops_TownLocationTownName",
                table: "WShops");

            migrationBuilder.DropColumn(
                name: "StreetLocation",
                table: "WShops");

            migrationBuilder.DropColumn(
                name: "TownLocationTownName",
                table: "WShops");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StreetLocation",
                table: "WShops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TownLocationTownName",
                table: "WShops",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WTowns",
                columns: table => new
                {
                    TownName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MayorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SalesTaxBlue = table.Column<int>(type: "int", nullable: false),
                    SalesTaxGreen = table.Column<int>(type: "int", nullable: false),
                    SalesTaxOrange = table.Column<int>(type: "int", nullable: false),
                    SalesTaxPurple = table.Column<int>(type: "int", nullable: false),
                    SalesTaxRed = table.Column<int>(type: "int", nullable: false),
                    SalesTaxYellow = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WTowns", x => x.TownName);
                    table.ForeignKey(
                        name: "FK_WTowns_AspNetUsers_MayorId",
                        column: x => x.MayorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WShops_TownLocationTownName",
                table: "WShops",
                column: "TownLocationTownName");

            migrationBuilder.CreateIndex(
                name: "IX_WTowns_MayorId",
                table: "WTowns",
                column: "MayorId");

            migrationBuilder.AddForeignKey(
                name: "FK_WShops_WTowns_TownLocationTownName",
                table: "WShops",
                column: "TownLocationTownName",
                principalTable: "WTowns",
                principalColumn: "TownName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
