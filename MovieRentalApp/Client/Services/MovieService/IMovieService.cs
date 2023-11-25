using System;
namespace MovieRentalApp.Client.Services.MovieService
{
	public interface IMovieService
	{
		event Action MoviesChanged;
		List<Movie> Movies { get; set; }
        public string Message { get; set; }

        Task GetMovies(string? genreUrl = null);
		Task<ServiceResponse<Movie>> GetMovie(int movieId);
	}
}

