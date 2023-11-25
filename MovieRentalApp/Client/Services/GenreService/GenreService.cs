using System;
namespace MovieRentalApp.Client.Services.GenreService
{
	public class GenreService : IGenreService
	{
		private readonly HttpClient _http;

		public GenreService(HttpClient http)
		{
			_http = http;
		}

		public List<Genre> Genres { get; set; } = new List<Genre>();
		public async Task GetGenres()
		{
			var response = await _http.GetFromJsonAsync<ServiceResponse<List<Genre>>>("api/Genre");
			if (response != null && response.Data != null)
				Genres = response.Data;
		}
	}
}

