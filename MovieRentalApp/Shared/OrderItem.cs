using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace MovieRentalApp.Shared
{
	public class OrderItem
	{
		public Order Order { get; set; }
		public int OrderId { get; set; }
		public Movie Movie { get; set; }
		public int MovieId { get; set; }
		public MovieType MovieType { get; set; }
		public int MovieTypeId { get; set; }
		public int Quantity { get; set; }
        public DateTime ReturnDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
		public decimal TotalPrice { get; set; }
	}
}

