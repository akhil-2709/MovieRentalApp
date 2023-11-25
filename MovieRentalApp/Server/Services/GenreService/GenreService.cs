using System;

namespace MovieRentalApp.Server.Services.GenreService
{
	public class GenreService : IGenreService
	{
        private readonly DataContext _context;

		public GenreService(DataContext context)
		{
            _context = context;
		}

        public async Task<ServiceResponse<List<Genre>>> GetGenres()
        {
            var genres = await _context.Genres.ToListAsync();
            return new ServiceResponse<List<Genre>>
            {
                Data = genres
            };
        }
    }
}

