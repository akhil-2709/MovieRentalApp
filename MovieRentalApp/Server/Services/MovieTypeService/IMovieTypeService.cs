using System;
namespace MovieRentalApp.Server.Services.MovieTypeService
{
	public interface IMovieTypeService
	{
        Task<ServiceResponse<List<MovieType>>> GetMovieTypes();
    }
}

