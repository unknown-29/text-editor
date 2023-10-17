using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace text_editor.Data.Migrations
{
    public partial class addedUserFiles1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "UserFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "UserFiles");
        }
    }
}
