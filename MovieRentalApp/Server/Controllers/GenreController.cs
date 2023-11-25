using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MovieRentalApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenreController : ControllerBase
	{
		private readonly IGenreService _genreService;

		public GenreController(IGenreService genreService)
		{
			_genreService = genreService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Genre>>>> GetGenres()
		{
			var result = await _genreService.GetGenres();
			return Ok(result);
		}
    }
}

