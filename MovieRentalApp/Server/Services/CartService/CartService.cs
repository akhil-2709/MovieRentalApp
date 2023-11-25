using System;
using System.Security.Claims;
using MovieRentalApp.Shared;

namespace MovieRentalApp.Server.Services.CartService
{
	public class CartService : ICartService
	{
        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public CartService(DataContext context, IAuthService authService)
		{
            _context = context;
            _authService = authService;
		}


        public async Task<ServiceResponse<List<CartMovieResponse>>> GetCartMovies(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartMovieResponse>>
            {
                Data = new List<CartMovieResponse>(),
            };

            foreach (var item in cartItems)
            {
                var movie = await _context.Movies
                    .Where(p => p.Id == item.MovieId)
                    .FirstOrDefaultAsync();

                if (movie == null)
                {
                    continue;
                }

                var movieVariant = await _context.MovieVariants
                    .Where(v => v.MovieId == item.MovieId
                        && v.MovieTypeId == item.MovieTypeId)
                    .Include(v => v.MovieType)
                    .FirstOrDefaultAsync();

                if (movieVariant == null)
                {
                    continue;
                }

                var cartMovie = new CartMovieResponse
                {
                    MovieId = movie.Id,
                    Title = movie.Title,
                    ImageUrl = movie.ImageUrl,
                    WeekDayPrice = movieVariant.WeekDayPrice,
                    MovieType = movieVariant.MovieType.Name,
                    MovieTypeId = movieVariant.MovieTypeId,
                    Quantity = item.Quantity,
                    ReturnDate = item.ReturnDate
                };

                result.Data.Add(cartMovie);
            }
            return result;
        }

        public async Task<ServiceResponse<List<CartMovieResponse>>> StoreCartItems(List<CartItem> cartItems)
        {
            cartItems.ForEach(cartItem => cartItem.UserId = _authService.GetUserId());
            _context.CartItems.AddRange(cartItems);
            await _context.SaveChangesAsync();

            return await GetDbCartMovies();
        }

        public async Task<ServiceResponse<int>> GetCartItemsCount()
        {
            var count = (await _context.CartItems.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync()).Count();
            return new ServiceResponse<int> { Data = count };
        }

        public async Task<ServiceResponse<List<CartMovieResponse>>> GetDbCartMovies()
        {
            return await GetCartMovies(await _context.CartItems
                .Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync());
        }

        public async Task<ServiceResponse<bool>> AddToCart(CartItem cartItem)
        {
            cartItem.UserId = _authService.GetUserId();
            var sameItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.MovieId == cartItem.MovieId &&
                ci.MovieTypeId == cartItem.MovieTypeId && ci.UserId == cartItem.UserId);
            if (sameItem == null)
            {
                _context.CartItems.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>{ Data = true};
        }

        public async Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem)
        {
            var dbCartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.MovieId == cartItem.MovieId &&
                ci.MovieTypeId == cartItem.MovieTypeId && ci.UserId == _authService.GetUserId());
            if (dbCartItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exist."
                };
            }

            dbCartItem.Quantity = cartItem.Quantity;
            dbCartItem.ReturnDate = cartItem.ReturnDate;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<bool>> RemoveItemFromCart(int movieId, int movieTypeId)
        {
            var dbCartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.MovieId == movieId &&
                ci.MovieTypeId == movieTypeId && ci.UserId == _authService.GetUserId());
            if (dbCartItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exist."
                };
            }

            _context.CartItems.Remove(dbCartItem);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}

