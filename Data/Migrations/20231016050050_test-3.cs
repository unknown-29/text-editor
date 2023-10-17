using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace text_editor.Data.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isShared",
                table: "UserFiles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isShared",
                table: "UserFiles");
        }
    }
}
