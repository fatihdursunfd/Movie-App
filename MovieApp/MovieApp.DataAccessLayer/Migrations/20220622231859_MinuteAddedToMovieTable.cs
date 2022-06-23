using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Data.Migrations
{
    public partial class MinuteAddedToMovieTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Minute",
                table: "Movies",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Minute",
                table: "Movies");
        }
    }
}
