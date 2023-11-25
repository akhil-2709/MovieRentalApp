using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRentalApp.Shared
{
	public class Movie
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;

		public Genre? Genre { get; set; }
		public int GenreId { get; set; }
		public bool Featured { get; set; } = false;

		public List<MovieVariant> Variants { get; set; } = new List<MovieVariant>();

	}
}

