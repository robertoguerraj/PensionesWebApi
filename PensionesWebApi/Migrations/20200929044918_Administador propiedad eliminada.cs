using Microsoft.EntityFrameworkCore.Migrations;

namespace PensionesWebApi.Migrations
{
    public partial class Administadorpropiedadeliminada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "administrador",
                table: "usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "administrador",
                table: "usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
