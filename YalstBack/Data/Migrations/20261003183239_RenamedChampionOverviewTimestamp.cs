using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YalstBack.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamedChampionOverviewTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTimestamp",
                table: "ChampionOverviews",
                newName: "LastUpdated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "ChampionOverviews",
                newName: "StartTimestamp");
        }
    }
}
