using System;
namespace MovieRentalApp.Server.Services.GenreService
{
	public interface IGenreService
	{
		Task<ServiceResponse<List<Genre>>> GetGenres();
	}

}

