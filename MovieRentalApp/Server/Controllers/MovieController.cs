using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieRentalApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Movie>>>> GetMovies()
        {
            var result = await _movieService.GetMoviesAsync();
            
            return Ok(result);
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult<ServiceResponse<Movie>>> GetMovie(int movieId)
        {
            var result = await _movieService.GetMovieAsync(movieId);

            return Ok(result);
        }

        [HttpGet("genre/{genreUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Movie>>>> GetMoviesByGenre(string genreUrl)
        {
            var result = await _movieService.GetMoviesByGenre(genreUrl);
            return Ok(result);
        }

        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<List<Movie>>>> GetFeaturedMovies()
        {
            var result = await _movieService.GetFeaturedMovies();
            return Ok(result);
        }
    }
}
