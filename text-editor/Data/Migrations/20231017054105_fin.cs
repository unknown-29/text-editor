using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace text_editor.Data.Migrations
{
    public partial class fin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "share",
                columns: table => new
                {
                    Sender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reciever = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "share");
        }
    }
}
