using Microsoft.EntityFrameworkCore.Migrations;

namespace SagamoreCarsDAL.Migrations
{
    public partial class AddCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cost",
                table: "CarAd",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "CarAd");
        }
    }
}
