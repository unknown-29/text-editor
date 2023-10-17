using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace text_editor.Data.Migrations
{
    public partial class addedUserFiles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "UserFiles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_userId",
                table: "UserFiles",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFiles_AspNetUsers_userId",
                table: "UserFiles",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFiles_AspNetUsers_userId",
                table: "UserFiles");

            migrationBuilder.DropIndex(
                name: "IX_UserFiles_userId",
                table: "UserFiles");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "UserFiles");
        }
    }
}
