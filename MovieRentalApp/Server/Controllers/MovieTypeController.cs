using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MovieRentalApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class MovieTypeController : ControllerBase
    { 
        private readonly IMovieTypeService _movieTypeService;

        public MovieTypeController(IMovieTypeService movieTypeService)
		{
            _movieTypeService = movieTypeService;
		}

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<MovieType>>>> GetMovieTypes()
        {
            var response = await _movieTypeService.GetMovieTypes();
            return Ok(response);
        }
    }
}

