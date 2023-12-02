using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRentalApp.Shared
{
	public class Movie
	{
		public int Id { get; set; }

		[Required]
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;

		public Genre? Genre { get; set; }
		public int GenreId { get; set; }
		public bool Featured { get; set; } = false;

		public List<MovieVariant> Variants { get; set; } = new List<MovieVariant>();
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;

        [NotMapped]
        public bool Editing { get; set; } = false;

        [NotMapped]
        public bool IsNew { get; set; } = false;

    }
}

