using System;
using System.Globalization;
using Blazored.LocalStorage;
using MovieRentalApp.Client.Services.AuthService;
using MovieRentalApp.Shared;

namespace MovieRentalApp.Client.Services.CartService
{
	public class CartService : ICartService
	{
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;
        private readonly IAuthService _authService;

		public CartService(ILocalStorageService localStorage, HttpClient http,
            IAuthService authService)
		{
            _localStorage = localStorage;
            _http = http;
            _authService = authService;
            
		}

        public event Action OnChange;

        public async Task AddToCart(CartItem cartItem)
        {
            Console.WriteLine("userauth"+ _authService.IsUserAuthenticated().ToString());
            if (await _authService.IsUserAuthenticated())
            {
                await _http.PostAsJsonAsync("api/cart/add", cartItem);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    cart = new List<CartItem>();
                }

                var sameItem = cart.Find(x => x.MovieId == cartItem.MovieId &&
                    x.MovieTypeId == cartItem.MovieTypeId);
                if (sameItem == null)
                {
                    cart.Add(cartItem);
                }
                else
                {
                    sameItem.Quantity += cartItem.Quantity;
                }
                await _localStorage.SetItemAsync("cart", cart);
            }

            await GetCartItemsCount();
        }

        public async Task GetCartItemsCount()
        {
            if (await _authService.IsUserAuthenticated())
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<int>>("api/cart/count");
                var count = result.Data;

                await _localStorage.SetItemAsync<int>("cartItemsCount", count);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                await _localStorage.SetItemAsync<int>("cartItemsCount", cart != null ? cart.Count : 0);
            }
            OnChange.Invoke();
        }

        public async Task<List<CartMovieResponse>> GetCartMovies()
        {
            if (await _authService.IsUserAuthenticated())
            {
                var response = await _http.GetFromJsonAsync<ServiceResponse<List<CartMovieResponse>>>("api/cart");
                return response.Data;
            }
            else
            {
                var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cartItems == null)
                    return new List<CartMovieResponse>();
                var response = await _http.PostAsJsonAsync("api/cart/movies", cartItems);
                var cartMovies =
                    await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartMovieResponse>>>();
                return cartMovies.Data;
            }

        }

        public async Task RemoveMovieFromCart(int movieId, int movieTypeId)
        {
            if (await _authService.IsUserAuthenticated())
            {
                await _http.DeleteAsync($"api/cart/{movieId}/{movieTypeId}");
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    return;
                }

                var cartItem = cart.Find(x => x.MovieId == movieId
                    && x.MovieTypeId == movieTypeId);
                if (cartItem != null)
                {
                    cart.Remove(cartItem);
                    await _localStorage.SetItemAsync("cart", cart);
                }
            }
        }

        public async Task StoreCartItems(bool emptyLocalCart = false)
        {
            var localCart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (localCart == null)
            {
                return;
            }

            await _http.PostAsJsonAsync("api/cart", localCart);

            if (emptyLocalCart)
            {
                await _localStorage.RemoveItemAsync("cart");
            }
        }

        public async Task UpdateQuantity(CartMovieResponse movie)
        {
            if (await _authService.IsUserAuthenticated())
            {
                var request = new CartItem
                {
                    MovieId = movie.MovieId,
                    Quantity = movie.Quantity,
                    MovieTypeId = movie.MovieTypeId,
                    ReturnDate = movie.ReturnDate
                };
                await _http.PutAsJsonAsync("api/cart/update-quantity", request);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    return;
                }

                var cartItem = cart.Find(x => x.MovieId == movie.MovieId
                    && x.MovieTypeId == movie.MovieTypeId);
                if (cartItem != null)
                {
                    cartItem.Quantity = movie.Quantity;
                    cartItem.ReturnDate = movie.ReturnDate;
                    await _localStorage.SetItemAsync("cart", cart);
                }
            }
        }

        public async Task UpdateReturnDate(string date, CartMovieResponse movie)
        {
            DateTime Date= DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            
            if (await _authService.IsUserAuthenticated())
            {
                var request = new CartItem
                {
                    MovieId = movie.MovieId,
                    Quantity = movie.Quantity,
                    MovieTypeId = movie.MovieTypeId,
                    ReturnDate = Date
                };
                Console.WriteLine("Client: "+request.ReturnDate.ToString());
                await _http.PutAsJsonAsync("api/cart/update-quantity", request);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    return;
                }

                var cartItem = cart.Find(x => x.MovieId == movie.MovieId
                    && x.MovieTypeId == movie.MovieTypeId);
                if (cartItem != null)
                {
                    cartItem.Quantity = movie.Quantity;
                    cartItem.ReturnDate = movie.ReturnDate;
                    await _localStorage.SetItemAsync("cart", cart);
                }
            }
        }
    }
}

