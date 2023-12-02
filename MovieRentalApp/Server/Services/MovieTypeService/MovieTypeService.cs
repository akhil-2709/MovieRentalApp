using System;
namespace MovieRentalApp.Server.Services.MovieTypeService
{
	public class MovieTypeService : IMovieTypeService
	{
        private readonly DataContext _context;

        public MovieTypeService(DataContext context)
		{
            _context = context;
        }

        public async Task<ServiceResponse<List<MovieType>>> GetMovieTypes()
        {
            var movieTypes = await _context.MovieTypes.ToListAsync();
            return new ServiceResponse<List<MovieType>> { Data = movieTypes };
        }
    }
}

