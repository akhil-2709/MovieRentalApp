using System;
namespace MovieRentalApp.Client.Services.GenreService
{
	public interface IGenreService
	{
		event Action OnChange;
		List<Genre> Genres { get; set; }
		List<Genre> AdminGenres { get; set; }
		Task GetGenres();
		Task GetAdminGenres();
		Task AddGenre(Genre genre);
        Task UpdateGenre(Genre genre);
        Task DeleteGenre(int genreId);
		Genre CreateNewGenre();
    }
}

