using Microsoft.EntityFrameworkCore;

namespace GamingVault.Data
{
	public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
	{
		public DbSet<VideoGame> VideoGames => Set<VideoGame>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<VideoGame>().HasData(
				new VideoGame
				{
					Id = 1,
					Title = "The Legend of Zelda: Breath of the Wild",
					Genre = "Action-adventure",
					Platform = "Nintendo Switch",
					ReleaseDate = "March 3, 2017",
					Publisher = "Nintendo",
					Developer = "Nintendo EPD",
					Description = "An open-world action-adventure game set in a post-apocalyptic Hyrule.",
					Rating = "10/10",
					Price = "$59.99",
					Review = "A masterpiece of game design and storytelling."
				},
				new VideoGame
				{
					Id = 2,
					Title = "The Witcher 3: Wild Hunt",
					Genre = "Action RPG",
					Platform = "PC, PS4, Xbox One, Nintendo Switch",
					ReleaseDate = "May 19, 2015",
					Publisher = "CD Projekt",
					Developer = "CD Projekt Red",
					Description = "An open-world RPG set in a fantasy world filled with monsters and magic.",
					Rating = "7/10",
					Price = "$39.99",
					Review = "An epic tale of Geralt of Rivia and his adventures."
				}
			);
		}
	}
}
