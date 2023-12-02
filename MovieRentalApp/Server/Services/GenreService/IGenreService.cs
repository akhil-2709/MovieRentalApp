using System;
namespace MovieRentalApp.Server.Services.GenreService
{
	public interface IGenreService
	{
		Task<ServiceResponse<List<Genre>>> GetGenres();
        Task<ServiceResponse<List<Genre>>> GetAdminGenres();
        Task<ServiceResponse<List<Genre>>> AddGenre(Genre genre);
        Task<ServiceResponse<List<Genre>>> DeleteGenre(int id);
        Task<ServiceResponse<List<Genre>>> UpdateGenre(Genre genre);
    }

}

