using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GamingVault.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "Id", "Description", "Developer", "Genre", "Platform", "Price", "Publisher", "Rating", "ReleaseDate", "Review", "Title" },
                values: new object[,]
                {
                    { 1, "An open-world action-adventure game set in a post-apocalyptic Hyrule.", "Nintendo EPD", "Action-adventure", "Nintendo Switch", "$59.99", "Nintendo", "10/10", "March 3, 2017", "A masterpiece of game design and storytelling.", "The Legend of Zelda: Breath of the Wild" },
                    { 2, "An open-world RPG set in a fantasy world filled with monsters and magic.", "CD Projekt Red", "Action RPG", "PC, PS4, Xbox One, Nintendo Switch", "$39.99", "CD Projekt", "7/10", "May 19, 2015", "An epic tale of Geralt of Rivia and his adventures.", "The Witcher 3: Wild Hunt" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
