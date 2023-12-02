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
        public List<Genre> AdminGenres { get; set; } = new List<Genre>();

        public event Action OnChange;

        public async Task AddGenre(Genre genre)
        {
            var response = await _http.PostAsJsonAsync("api/Genre/admin", genre);
            AdminGenres = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Genre>>>()).Data;
            await GetGenres();
            OnChange.Invoke();
        }

        public Genre CreateNewGenre()
        {
            var newGenre = new Genre { IsNew = true, Editing = true };
            AdminGenres.Add(newGenre);
            OnChange.Invoke();
            return newGenre;
        }

        public async Task DeleteGenre(int genreId)
        {
            var response = await _http.DeleteAsync($"api/Genre/admin/{genreId}");
            AdminGenres = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Genre>>>()).Data;
            await GetGenres();
            OnChange.Invoke();
        }

        public async Task GetAdminGenres()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Genre>>>("api/Genre/admin");
            if (response != null && response.Data != null)
                AdminGenres = response.Data;
        }

        public async Task GetGenres()
		{
			var response = await _http.GetFromJsonAsync<ServiceResponse<List<Genre>>>("api/Genre");
			if (response != null && response.Data != null)
				Genres = response.Data;
		}

        public async Task UpdateGenre(Genre genre)
        {
            var response = await _http.PutAsJsonAsync($"api/Genre/admin", genre);
            AdminGenres = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Genre>>>()).Data;
            await GetGenres();
            OnChange.Invoke();
        }
    }
}

