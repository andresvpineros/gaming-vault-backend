using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamingVault.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VideoGameController : ControllerBase
	{
		static private List<VideoGame> videoGames = new List<VideoGame>
		{
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
		};

		// GET: api/<VideoGameController>
		[HttpGet]
		public ActionResult<List<VideoGame>> GetVideoGames()
		{
			return Ok(videoGames);
		}

		// GET api/<VideoGameController>/5
		[HttpGet("{id}")]
		public ActionResult<VideoGame> GetVideoGameById(int id)
		{
			var videoGame = videoGames.FirstOrDefault(v => v.Id == id);
			if (videoGame is null)
			{
				return NotFound();
			}

			return Ok(videoGame);
		}

		// POST api/<VideoGameController>
		[HttpPost]
		public ActionResult<VideoGame> AddVideoGame(VideoGame newGame)
		{
			if (newGame is null)
			{
				return BadRequest();
			}

			newGame.Id = videoGames.Max(g => g.Id) + 1;
			videoGames.Add(newGame);

			return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
		}

		// PUT api/<VideoGameController>/5
		[HttpPut("{id}")]
		public IActionResult UpdateVideoGame(int id, VideoGame videoGame)
		{
			var game = videoGames.FirstOrDefault(v => v.Id == id);
			if (game is null)
			{
				return NotFound();
			}

			game.Title = videoGame.Title;
			game.Genre = videoGame.Genre;
			game.Platform = videoGame.Platform;
			game.ReleaseDate = videoGame.ReleaseDate;
			game.Publisher = videoGame.Publisher;
			game.Developer = videoGame.Developer;
			game.Description = videoGame.Description;
			game.Rating = videoGame.Rating;
			game.Price = videoGame.Price;
			game.Review = videoGame.Review;

			return NoContent();
		}

		// DELETE api/<VideoGameController>/5
		[HttpDelete("{id}")]
		public IActionResult DeleteVideoGame(int id)
		{
			var game = videoGames.FirstOrDefault(v => v.Id == id);
			if (game is null)
			{
				return NotFound();
			}

			videoGames.Remove(game);

			return NoContent();
		}
	}
}
