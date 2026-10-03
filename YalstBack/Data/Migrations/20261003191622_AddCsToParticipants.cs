using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YalstBack.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCsToParticipants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NeutralMinionsKilled",
                table: "MatchParticipants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalMinionsKilled",
                table: "MatchParticipants",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeutralMinionsKilled",
                table: "MatchParticipants");

            migrationBuilder.DropColumn(
                name: "TotalMinionsKilled",
                table: "MatchParticipants");
        }
    }
}
