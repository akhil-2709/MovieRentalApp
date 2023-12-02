using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Genre>>>> GetAdminGenres()
        {
            var result = await _genreService.GetAdminGenres();
            return Ok(result);
        }

        [HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Genre>>>> DeleteGenre(int id)
        {
            var result = await _genreService.DeleteGenre(id);
            return Ok(result);
        }

        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Genre>>>> AddGenre(Genre genre)
        {
            var result = await _genreService.AddGenre(genre);
            return Ok(result);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Genre>>>> UpdateGenre(Genre genre)
        {
            var result = await _genreService.UpdateGenre(genre);
            return Ok(result);
        }
    }
}

