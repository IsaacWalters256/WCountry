using Microsoft.EntityFrameworkCore.Migrations;

namespace WCountry.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_ReviewerId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_WShops_WShopName1",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_WShopName1",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "WShopName1",
                table: "Review");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ReviewerId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewerId");

            migrationBuilder.AlterColumn<string>(
                name: "WShopName",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "ResponseID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_WShopName",
                table: "Reviews",
                column: "WShopName");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ReviewerId",
                table: "Reviews",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_WShops_WShopName",
                table: "Reviews",
                column: "WShopName",
                principalTable: "WShops",
                principalColumn: "WShopName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ReviewerId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_WShops_WShopName",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_WShopName",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Review",
                newName: "IX_Review_ReviewerId");

            migrationBuilder.AlterColumn<string>(
                name: "WShopName",
                table: "Review",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WShopName1",
                table: "Review",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "ResponseID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_WShopName1",
                table: "Review",
                column: "WShopName1");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_ReviewerId",
                table: "Review",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_WShops_WShopName1",
                table: "Review",
                column: "WShopName1",
                principalTable: "WShops",
                principalColumn: "WShopName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
