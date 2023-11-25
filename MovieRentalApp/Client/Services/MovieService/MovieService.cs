using System;

namespace MovieRentalApp.Client.Services.MovieService
{ 
	public class MovieService : IMovieService
	{
        private readonly HttpClient _http;

        public MovieService(HttpClient http)
        {
            _http = http;
        }
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public string Message { get; set; } = "Loading Movies...";

        public event Action MoviesChanged;

        public async Task<ServiceResponse<Movie>> GetMovie(int movieId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Movie>>($"api/movie/{movieId}");
            return result;
        }

        public async Task GetMovies(string? genreUrl = null)
        {
            var result = genreUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Movie>>>("api/movie/featured") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Movie>>>($"api/movie/genre/{genreUrl}");
            if (result != null && result.Data != null)
                Movies = result.Data;

            MoviesChanged.Invoke();
        } 
    }
}

