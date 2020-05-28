using Microsoft.EntityFrameworkCore.Migrations;

namespace SagamoreCarsDAL.Migrations
{
    public partial class Addyear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "CarAd",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "CarAd");
        }
    }
}
