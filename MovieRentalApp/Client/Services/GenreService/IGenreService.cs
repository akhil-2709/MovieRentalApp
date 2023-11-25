using System;
namespace MovieRentalApp.Client.Services.GenreService
{
	public interface IGenreService
	{
		List<Genre>Genres { get; set; }
		Task GetGenres();
	}
}

