using System;
namespace MovieRentalApp.Client.Services.CartService
{
	public interface ICartService
	{
		event Action OnChange;

		Task AddToCart(CartItem cartItem);


		Task<List<CartMovieResponse>> GetCartMovies();

		Task RemoveMovieFromCart(int movieId, int movieTypeId);
		Task UpdateQuantity(CartMovieResponse movie);
        Task UpdateReturnDate(string date, CartMovieResponse movie);

        Task StoreCartItems(bool emptyLocalCart);
		Task GetCartItemsCount();

	}
}

