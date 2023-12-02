using System;
namespace MovieRentalApp.Client.Services.MovieTypeService
{
	public interface IMovieTypeService
	{
        event Action OnChange;
        public List<MovieType> MovieTypes { get; set; }
        Task GetMovieTypes();
    }
}

