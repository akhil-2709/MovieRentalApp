using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Movie>>>> GetAdminMovies()
        {
            var result = await _movieService.GetAdminMovies();

            return Ok(result);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Movie>>> CreateMovie(Movie movie)
        {
            var result = await _movieService.CreateMovie(movie);

            return Ok(result);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Movie>>> UpdateMovie(Movie movie)
        {
            var result = await _movieService.UpdateMovie(movie);

            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteMovie(int id)
        {
            var result = await _movieService.DeleteMovie(id);

            return Ok(result);
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
