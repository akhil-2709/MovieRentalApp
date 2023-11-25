using System;
namespace MovieRentalApp.Shared
{
	public class OrderDetailsMovieResponse
	{
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string MovieType { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}

