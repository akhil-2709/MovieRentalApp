using System;
using System.Security.Claims;

namespace MovieRentalApp.Server.Services.OrderService
{
	public class OrderService : IOrderService
	{
        private readonly DataContext _context;
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;

		public OrderService(DataContext context, ICartService cartService,
            IAuthService authService)
		{
            _context = context;
            _cartService = cartService;
            _authService = authService;
		}

        public async Task<ServiceResponse<OrderDetailsResponse>> GetOrderDetails(int orderId)
        {
            var response = new ServiceResponse<OrderDetailsResponse>();
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Movie)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MovieType)
                .Where(o => o.UserId == _authService.GetUserId() && o.Id == orderId)
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                response.Success = false;
                response.Message = "Order not found.";
                return response;
            }

            var orderDetailsResponse = new OrderDetailsResponse
            {
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Movies = new List<OrderDetailsMovieResponse>()
            };

            order.OrderItems.ForEach(item =>
            orderDetailsResponse.Movies.Add(new OrderDetailsMovieResponse
            {
                MovieId = item.MovieId,
                ImageUrl = item.Movie.ImageUrl,
                MovieType = item.MovieType.Name,
                Quantity = item.Quantity,
                Title = item.Movie.Title,
                ReturnDate = item.ReturnDate,
                TotalPrice = item.TotalPrice
            }));

            response.Data = orderDetailsResponse;

            return response;
        }

        public async Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders()
        {
            var response = new ServiceResponse<List<OrderOverviewResponse>>();
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Movie)
                .Where(o => o.UserId == _authService.GetUserId())
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var orderResponse = new List<OrderOverviewResponse>();
            orders.ForEach(o => orderResponse.Add(new OrderOverviewResponse
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                Movie = o.OrderItems.Count > 1 ?
                    $"{o.OrderItems.First().Movie.Title} and" +
                    $" {o.OrderItems.Count - 1} more..." :
                    o.OrderItems.First().Movie.Title,
                MovieImageUrl = o.OrderItems.First().Movie.ImageUrl

            }));

            response.Data = orderResponse;
            return response;

        }

        public async Task<ServiceResponse<bool>> PlaceOrder()
        {
            var movies = (await _cartService.GetDbCartMovies()).Data;
            decimal totalPrice = 0;
            movies.ForEach(movie => totalPrice += movie.WeekDayPrice * movie.Quantity * getDays(movie.ReturnDate));

            var orderItems = new List<OrderItem>();
            movies.ForEach(movie => orderItems.Add(new OrderItem
            {
                MovieId = movie.MovieId,
                MovieTypeId = movie.MovieTypeId,
                Quantity = movie.Quantity,
                ReturnDate = movie.ReturnDate,
                TotalPrice = movie.WeekDayPrice * movie.Quantity * getDays(movie.ReturnDate)
            }));

            var order = new Order
            {
                UserId = _authService.GetUserId(),
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };

            _context.Orders.Add(order);

            _context.CartItems.RemoveRange(_context.CartItems
                .Where(ci => ci.UserId == _authService.GetUserId()));

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public int getDays(DateTime returnDate)
        {
            DateTime currentDate = DateTime.Now;
            return (returnDate - currentDate).Days;
        }
    }
}

