using System;
namespace MovieRentalApp.Server.Services.MovieService
{
	public class MovieService : IMovieService
	{
		private readonly DataContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public MovieService(DataContext context, IHttpContextAccessor httpContextAccessor)
		{
			_context = context;
			_httpContextAccessor = httpContextAccessor;
		}

        public async Task<ServiceResponse<Movie>> CreateMovie(Movie movie)
        {
            foreach (var variant in movie.Variants)
			{
				variant.MovieType = null;
			}
			_context.Movies.Add(movie);
			await _context.SaveChangesAsync();
			return new ServiceResponse<Movie> { Data = movie };
        }

        public async Task<ServiceResponse<bool>> DeleteMovie(int movieId)
        {
			var dbMovie = await _context.Movies.FindAsync(movieId);
			if (dbMovie == null)
			{
				return new ServiceResponse<bool>
				{
					Success = false,
					Data = false,
					Message = "Movie not found"
				};
			}
			dbMovie.Deleted = true;
			await _context.SaveChangesAsync();
			return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<List<Movie>>> GetAdminMovies()
        {
            var response = new ServiceResponse<List<Movie>>
            {
                Data = await _context.Movies
                    .Where(p => !p.Deleted)
                    .Include(p => p.Variants.Where(v => !v.Deleted))
					.ThenInclude(v => v.MovieType)
					.ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Movie>>> GetFeaturedMovies()
		{
			var response = new ServiceResponse<List<Movie>>
			{
				Data = await _context.Movies
					 .Where(p => p.Featured && p.Visible && !p.Deleted)
					 .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
					 .ToListAsync()
			};

			return response;
		}

        public async Task<ServiceResponse<Movie>> GetMovieAsync(int movieId)
        {
			var response = new ServiceResponse<Movie>();
			Movie movie = null;

			if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
			{
                 movie = await _context.Movies
                .Include(p => p.Variants.Where(v => !v.Deleted))
                .ThenInclude(v => v.MovieType)
                .FirstOrDefaultAsync(p => p.Id == movieId && !p.Deleted);
            }
			else
			{
                movie = await _context.Movies
                .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                .ThenInclude(v => v.MovieType)
                .FirstOrDefaultAsync(p => p.Id == movieId && !p.Deleted && p.Visible);
            }
	
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
				Data = await _context.Movies
					.Where(p => p.Visible && !p.Deleted)
					.Include(p => p.Variants.Where(v => v.Visible && !v.Deleted)).ToListAsync()
			};
			return response;
		}

        public async Task<ServiceResponse<List<Movie>>> GetMoviesByGenre(string genreUrl)
        {
			var response = new ServiceResponse<List<Movie>>
			{
				Data = await _context.Movies
					.Where(p => p.Genre.Url.ToLower().Equals(genreUrl.ToLower()) &&
						p.Visible && !p.Deleted)
                    .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                    .ToListAsync()
			};
            return response;
        }

        public async Task<ServiceResponse<Movie>> UpdateMovie(Movie movie)
        {
            var dbMovie = await _context.Movies.FindAsync(movie.Id);
            if (dbMovie == null)
            {
                return new ServiceResponse<Movie>
                {
                    Success = false,
                    Message = "Movie not found"
                };
            }

			dbMovie.Title = movie.Title;
			dbMovie.Description = movie.Description;
			dbMovie.ImageUrl = movie.ImageUrl;
			dbMovie.GenreId = movie.GenreId;
			dbMovie.Visible = movie.Visible;
			dbMovie.Featured = movie.Featured;

			foreach (var variant in movie.Variants)
			{
				var dbVariant = await _context.MovieVariants
					.SingleOrDefaultAsync(v => v.MovieId == variant.MovieId &&
						v.MovieTypeId == variant.MovieTypeId);
				if (dbVariant == null)
				{
					variant.MovieType = null;
					_context.MovieVariants.Add(variant);
				}
				else
				{
					dbVariant.MovieTypeId = variant.MovieTypeId;
					dbVariant.WeekDayPrice = variant.WeekDayPrice;
					dbVariant.WeekendPrice = variant.WeekendPrice;
					dbVariant.Count = variant.Count;
					dbVariant.Visible = variant.Visible;
					dbVariant.Deleted = variant.Deleted;
				}
			}
			await _context.SaveChangesAsync();
			return new ServiceResponse<Movie> { Data = movie };
        }
    }
}

