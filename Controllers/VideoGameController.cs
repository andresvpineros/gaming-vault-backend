using GamingVault.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamingVault.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VideoGameController(VideoGameDbContext context) : ControllerBase
	{
		private readonly VideoGameDbContext _context = context;


		// GET: api/<VideoGameController>
		[HttpGet]
		public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
		{
			return Ok(await _context.VideoGames.ToListAsync());
		}

		//// GET api/<VideoGameController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
		{
			var videoGame = await _context.VideoGames.FindAsync(id);
			if (videoGame is null)
			{
				return NotFound();
			}

			return Ok(videoGame);
		}

		//// POST api/<VideoGameController>
		[HttpPost]
		public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame newGame)
		{
			if (newGame is null)
			{
				return BadRequest();
			}

			_context.VideoGames.Add(newGame);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
		}

		//// PUT api/<VideoGameController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateVideoGame(int id, VideoGame updatedGame)
		{
			var game = await _context.VideoGames.FindAsync(id);
			if (game is null)
			{
				return NotFound();
			}

			game.Title = updatedGame.Title;
			game.Genre = updatedGame.Genre;
			game.Platform = updatedGame.Platform;
			game.ReleaseDate = updatedGame.ReleaseDate;
			game.Publisher = updatedGame.Publisher;
			game.Developer = updatedGame.Developer;
			game.Description = updatedGame.Description;
			game.Rating = updatedGame.Rating;
			game.Price = updatedGame.Price;
			game.Review = updatedGame.Review;

			await _context.SaveChangesAsync();
			return NoContent();
		}

		//// DELETE api/<VideoGameController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteVideoGame(int id)
		{
			var game = await _context.VideoGames.FindAsync(id);
			if (game is null)
			{
				return NotFound();
			}

			_context.VideoGames.Remove(game);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
