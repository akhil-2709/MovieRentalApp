using System;
namespace MovieRentalApp.Shared
{
	public class OrderDetailsResponse
	{
		public DateTime OrderDate { get; set; }
		public decimal TotalPrice { get; set; }
		public List<OrderDetailsMovieResponse> Movies { get; set; }
	}
}

