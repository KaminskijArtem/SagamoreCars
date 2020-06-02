using Microsoft.EntityFrameworkCore.Migrations;

namespace SagamoreCarsDAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarAd",
                columns: table => new
                {
                    Href = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAd", x => x.Href);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarAd");
        }
    }
}
