using System;
namespace MovieRentalApp.Server.Services.MovieService
{
	public class MovieService : IMovieService
	{
		private readonly DataContext _context;
		public MovieService(DataContext context)
		{
			_context = context;
		}

		public async Task<ServiceResponse<List<Movie>>> GetFeaturedMovies()
		{
			var response = new ServiceResponse<List<Movie>>
			{
				Data = await _context.Movies
					 .Where(p => p.Featured)
					 .Include(p => p.Variants)
					 .ToListAsync()
			};

			return response;
		}

        public async Task<ServiceResponse<Movie>> GetMovieAsync(int movieId)
        {
			var response = new ServiceResponse<Movie>();
			var movie = await _context.Movies
				.Include(p => p.Variants)
				.ThenInclude(v => v.MovieType)
				.FirstOrDefaultAsync(p => p.Id == movieId);
			if (movie == null)
			{
				response.Success = false;
				response.Message = "This Movie does not exist!";
			}
			else
			{
				response.Data = movie;
			}

			return response;
        }

        public async Task<ServiceResponse<List<Movie>>> GetMoviesAsync()
		{
			var response = new ServiceResponse<List<Movie>>
			{
				Data = await _context.Movies.Include(p => p.Variants).ToListAsync()
			};
			return response;
		}

        public async Task<ServiceResponse<List<Movie>>> GetMoviesByGenre(string genreUrl)
        {
			var response = new ServiceResponse<List<Movie>>
			{
				Data = await _context.Movies
					.Where(p => p.Genre.Url.ToLower().Equals(genreUrl.ToLower()))
                    .Include(p => p.Variants)
                    .ToListAsync()
			};
            return response;
        }
    }
}

