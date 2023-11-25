using System;
namespace MovieRentalApp.Server.Services.CartService
{
	public interface ICartService
	{
		Task<ServiceResponse<List<CartMovieResponse>>> GetCartMovies(List<CartItem> cartItems);
        Task<ServiceResponse<List<CartMovieResponse>>> StoreCartItems(List<CartItem> cartItems);
		Task<ServiceResponse<int>> GetCartItemsCount();
		Task<ServiceResponse<List<CartMovieResponse>>> GetDbCartMovies();

		Task<ServiceResponse<bool>> AddToCart(CartItem cartItem);
		Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem);
		Task<ServiceResponse<bool>> RemoveItemFromCart(int movieId, int movieTypeId);

    }
}

