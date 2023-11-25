using System;
namespace MovieRentalApp.Shared
{
	public class CartMovieResponse
	{
		public int MovieId { get; set; }
		public string Title { get; set; } = string.Empty;
		public int MovieTypeId { get; set; }
		public string MovieType { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
		public decimal WeekDayPrice { get; set; }
		public int Quantity { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}

