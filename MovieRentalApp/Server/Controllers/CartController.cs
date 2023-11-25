﻿using System;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace MovieRentalApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly ICartService _cartService;
		public CartController(ICartService cartService)
		{
			_cartService = cartService;
		}

		[HttpPost("movies")]
		public async Task<ActionResult<ServiceResponse<List<CartMovieResponse>>>> GetCartMovies(List<CartItem> cartItems)
		{
			var result = await _cartService.GetCartMovies(cartItems);
			return Ok(result);
		}

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CartMovieResponse>>>> StoreCartItems(List<CartItem> cartItems)
        {
			
			var result = await _cartService.StoreCartItems(cartItems);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<bool>>> AddToCart(CartItem cartItem)
        {

            var result = await _cartService.AddToCart(cartItem);
            return Ok(result);
        }

        [HttpPut("update-quantity")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateQuantity(CartItem cartItem)
        {
            var result = await _cartService.UpdateQuantity(cartItem);
            return Ok(result);
        }

        [HttpDelete("{movieId}/{movieTypeId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> RemoveItemFromCart(int movieId, int movieTypeId )
        {

            var result = await _cartService.RemoveItemFromCart(movieId, movieTypeId);
            return Ok(result);
        }

        [HttpGet("count")]
		public async Task<ActionResult<ServiceResponse<int>>> GetCartItemsCount()
		{
			return await _cartService.GetCartItemsCount();
		}

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CartMovieResponse>>>> GetDbCartMovies()
        {
			var result = await _cartService.GetDbCartMovies();
			return Ok(result);
        }
    }
}

