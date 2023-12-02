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
        public List<Movie> AdminMovies { get; set; }

        public event Action MoviesChanged;

        public async Task<Movie> CreateMovie(Movie movie)
        {
            var result = await _http.PostAsJsonAsync("api/movie", movie);
            var newMovie = (await result.Content.ReadFromJsonAsync<ServiceResponse<Movie>>()).Data;
            return newMovie;
        }

        public async Task DeleteMovie(Movie movie)
        {
            var result = await _http.DeleteAsync($"api/movie/{movie.Id}");
        }

        public async Task GetAdminMovies()
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<Movie>>>("api/movie/admin");
            AdminMovies = result.Data;
            if (AdminMovies.Count == 0)
                Message = "No Movies Found";
        }

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

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var result = await _http.PutAsJsonAsync($"api/movie", movie);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<Movie>>();
            return content.Data;
        }
    }
}

