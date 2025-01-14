﻿using System;
namespace MovieRentalApp.Server.Services.OrderService
{
	public interface IOrderService
	{
		Task<ServiceResponse<bool>> PlaceOrder();
		Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders();
		Task<ServiceResponse<OrderDetailsResponse>> GetOrderDetails(int orderId);
		int getDays(DateTime returnDate);
		Task<ServiceResponse<bool>> Return(Movie movie);

    }
}

