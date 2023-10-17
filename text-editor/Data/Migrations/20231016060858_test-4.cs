using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace text_editor.Data.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isShared",
                table: "UserFiles");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "share");

            migrationBuilder.RenameColumn(
                name: "Reciever",
                table: "share",
                newName: "FileId");

            migrationBuilder.AddColumn<int>(
                name: "sharedId",
                table: "UserFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sharedId",
                table: "UserFiles");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "share",
                newName: "Reciever");

            migrationBuilder.AddColumn<bool>(
                name: "isShared",
                table: "UserFiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DocumentId",
                table: "share",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
