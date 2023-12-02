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

        public async Task<ServiceResponse<List<Genre>>> AddGenre(Genre genre)
        {
            genre.Editing = genre.IsNew = false;
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return await GetAdminGenres();
        }

        public async Task<ServiceResponse<List<Genre>>> DeleteGenre(int id)
        {
            Genre genre = await GetGenreById(id);
            if (genre == null)
            {
                return new ServiceResponse<List<Genre>>
                {
                    Success = false,
                    Message = "Genre not found"
                };
            }

            genre.Deleted = true;
            await _context.SaveChangesAsync();

            return await GetAdminGenres();
        }

        private async Task<Genre> GetGenreById(int id)
        {
            return await _context.Genres.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ServiceResponse<List<Genre>>> GetAdminGenres()
        {
            var genres = await _context.Genres
                .Where(c => !c.Deleted)
                .ToListAsync();
            return new ServiceResponse<List<Genre>>
            {
                Data = genres
            };
        }

        public async Task<ServiceResponse<List<Genre>>> GetGenres()
        {
            var genres = await _context.Genres
                .Where(c => !c.Deleted && c.Visible)
                .ToListAsync();
            return new ServiceResponse<List<Genre>>
            {
                Data = genres
            };
        }

        public async Task<ServiceResponse<List<Genre>>> UpdateGenre(Genre genre)
        {
            var dbGenre = await GetGenreById(genre.Id);
            if (dbGenre == null)
            {
                return new ServiceResponse<List<Genre>>
                {
                    Success = false,
                    Message = "Genre not found"
                };
            }

            dbGenre.Name = genre.Name;
            dbGenre.Url = genre.Url;
            dbGenre.Visible = genre.Visible;

            await _context.SaveChangesAsync();

            return await GetAdminGenres();

        }
    }
}

