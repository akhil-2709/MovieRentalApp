using System;
namespace MovieRentalApp.Client.Services.OrderService
{
	public interface IOrderService
	{ 
		Task PlaceOrder();

		Task<List<OrderOverviewResponse>> GetOrders();
		Task<OrderDetailsResponse> GetOrderDetails(int orderId);
		Task Return(int movieId);
	}
}

