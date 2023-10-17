using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace text_editor.Data.Migrations
{
    public partial class FileContent4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FileContent_file_id",
                table: "FileContent",
                column: "file_id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileContent_UserFiles_file_id",
                table: "FileContent",
                column: "file_id",
                principalTable: "UserFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileContent_UserFiles_file_id",
                table: "FileContent");

            migrationBuilder.DropIndex(
                name: "IX_FileContent_file_id",
                table: "FileContent");
        }
    }
}
