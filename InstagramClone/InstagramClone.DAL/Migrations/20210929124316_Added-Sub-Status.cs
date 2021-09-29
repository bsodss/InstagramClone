using Microsoft.EntityFrameworkCore.Migrations;

namespace InstagramClone.DAL.Migrations
{
    public partial class AddedSubStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "UserRelations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserRelations");
        }
    }
}
