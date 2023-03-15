using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hackatonBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class CreatedGamesDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "UserAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    PlayedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_GameId",
                table: "UserAnswers",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Games_GameId",
                table: "UserAnswers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Games_GameId",
                table: "UserAnswers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_GameId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "UserAnswers");
        }
    }
}
