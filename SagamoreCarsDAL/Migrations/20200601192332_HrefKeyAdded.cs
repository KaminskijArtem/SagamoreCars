using Microsoft.EntityFrameworkCore.Migrations;

namespace SagamoreCarsDAL.Migrations
{
    public partial class HrefKeyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarAd",
                table: "CarAd");

            migrationBuilder.AlterColumn<string>(
                name: "Href",
                table: "CarAd",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CarAd",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarAd",
                table: "CarAd",
                column: "Href");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarAd",
                table: "CarAd");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CarAd",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Href",
                table: "CarAd",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarAd",
                table: "CarAd",
                column: "Id");
        }
    }
}
