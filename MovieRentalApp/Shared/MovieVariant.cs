using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MovieRentalApp.Shared
{
	public class MovieVariant
	{
		[JsonIgnore]
		public Movie? Movie { get; set; }
		public int MovieId { get; set; }
		public MovieType? MovieType { get; set; }
		public int MovieTypeId { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal WeekDayPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal WeekendPrice { get; set; }

		public int Count { get; set; }

        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;

        [NotMapped]
        public bool Editing { get; set; } = false;

        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}

