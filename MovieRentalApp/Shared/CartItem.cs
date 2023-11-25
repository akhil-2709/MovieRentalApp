using System;
namespace MovieRentalApp.Shared
{
	public class CartItem
	{
		public int UserId { get; set; }
		public int MovieId { get; set; }
		public int MovieTypeId { get; set; }
		public int Quantity { get; set; } = 1;
        public DateTime ReturnDate { get; set; } = DateTime.Now;
    }
}

