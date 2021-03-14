using Microsoft.EntityFrameworkCore.Migrations;

namespace WCountry.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ResponseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WShopName = table.Column<string>(nullable: true),
                    ReviewNumber = table.Column<int>(nullable: false),
                    ReviewerId = table.Column<string>(nullable: true),
                    WShopName1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ResponseID);
                    table.ForeignKey(
                        name: "FK_Review_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_WShops_WShopName1",
                        column: x => x.WShopName1,
                        principalTable: "WShops",
                        principalColumn: "WShopName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReviewerId",
                table: "Review",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_WShopName1",
                table: "Review",
                column: "WShopName1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");
        }
    }
}
