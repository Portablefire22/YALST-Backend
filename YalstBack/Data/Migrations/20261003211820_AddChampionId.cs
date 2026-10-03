using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YalstBack.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddChampionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChampionId",
                table: "ChampionOverviews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChampionId",
                table: "ChampionOverviews");
        }
    }
}
