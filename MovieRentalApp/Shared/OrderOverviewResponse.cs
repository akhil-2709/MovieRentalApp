using System;
namespace MovieRentalApp.Shared
{
    public class OrderOverviewResponse
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Movie { get; set; }
        public string MovieImageUrl {get; set;}
    }
}

