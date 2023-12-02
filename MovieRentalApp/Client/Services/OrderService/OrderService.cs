using System;
using Microsoft.AspNetCore.Components;
using MovieRentalApp.Client.Pages.Admin;
using MovieRentalApp.Shared;
using Newtonsoft.Json;

namespace MovieRentalApp.Client.Services.OrderService
{
    public class OrderService : IOrderService
	{
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly NavigationManager _navigationManager;

		public OrderService(HttpClient http, AuthenticationStateProvider authStateProvider,
            NavigationManager navigationManager)
		{
            _http = http;
            _authStateProvider = authStateProvider;
            _navigationManager = navigationManager;
		}

        public async Task<OrderDetailsResponse> GetOrderDetails(int orderId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<OrderDetailsResponse>>($"api/order/{orderId}");
            return result.Data;
        }

        public async Task<List<OrderOverviewResponse>> GetOrders()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrderOverviewResponse>>>("api/order");
            return result.Data;
        }

        public async Task PlaceOrder()
        {
           if (await IsUserAuthenticated())
            {
                //await _http.PostAsync("api/order", null);
                HttpResponseMessage response = await _http.PostAsync("api/order", null);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON string into an anonymous object
                    var responseObject = JsonConvert.DeserializeAnonymousType(
                        responseBody,
                        new { data = false, success = true, message = "" }
                    );

                    if (responseObject.data == false)
                    {
                        _navigationManager.NavigateTo("ordererror");
                    }
                }
            }
            else
            {
                _navigationManager.NavigateTo("login");
            }
        }

        public async Task Return(int movieId)
        {
           var response = await _http.GetFromJsonAsync<ServiceResponse<Movie>>($"api/movie/{movieId}");
            await _http.PutAsJsonAsync($"api/movie", response.Data);
            //var content = await result.Content.ReadFromJsonAsync<ServiceResponse<Movie>>();

            
        }

        private async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;

        }
    }
}

