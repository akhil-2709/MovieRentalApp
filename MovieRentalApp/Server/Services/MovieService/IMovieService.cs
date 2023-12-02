using System;
using Microsoft.AspNetCore.Mvc;

namespace MovieRentalApp.Server.Services.MovieService
{
    public interface IMovieService
    {
        Task<ServiceResponse<List<Movie>>> GetMoviesAsync();

        Task<ServiceResponse<Movie>> GetMovieAsync(int movieId);

        Task<ServiceResponse<List<Movie>>> GetMoviesByGenre(string genreUrl);

        Task<ServiceResponse<List<Movie>>> GetFeaturedMovies();

        Task<ServiceResponse<List<Movie>>> GetAdminMovies();

        Task<ServiceResponse<Movie>> CreateMovie(Movie movie);

        Task<ServiceResponse<Movie>> UpdateMovie(Movie movie);

        Task<ServiceResponse<bool>> DeleteMovie(int movieId);
    }
}

