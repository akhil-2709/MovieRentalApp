using System;
namespace MovieRentalApp.Client.Services.MovieService
{
	public interface IMovieService
	{
		event Action MoviesChanged;
		List<Movie> Movies { get; set; }
		List<Movie> AdminMovies { get; set; }
        public string Message { get; set; }

        Task GetMovies(string? genreUrl = null);
		Task<ServiceResponse<Movie>> GetMovie(int movieId);

		Task GetAdminMovies();

        Task<Movie> CreateMovie(Movie movie);

        Task<Movie> UpdateMovie(Movie movie);

        Task DeleteMovie(Movie movie);
    }
}

