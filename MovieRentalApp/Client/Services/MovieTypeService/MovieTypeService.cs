using System;
using MovieRentalApp.Shared;

namespace MovieRentalApp.Client.Services.MovieTypeService
{
	public class MovieTypeService :IMovieTypeService
	{
        private readonly HttpClient _http;

        public MovieTypeService(HttpClient http)
        {
            _http = http;
        }

        public List<MovieType> MovieTypes { get; set; } = new List<MovieType>();

        public event Action OnChange;


        public async Task GetMovieTypes()
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<MovieType>>>("api/movietype");
            MovieTypes = result.Data;
        }

    }
}

