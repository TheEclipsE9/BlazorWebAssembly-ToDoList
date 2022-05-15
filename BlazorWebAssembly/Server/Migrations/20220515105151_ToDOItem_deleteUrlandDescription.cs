using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWebAssembly.Server.Migrations
{
    public partial class ToDOItem_deleteUrlandDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "ToDoItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ToDoItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "ToDoItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
