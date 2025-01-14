﻿using System;
namespace MovieRentalApp.Shared
{
	public class User
	{
		public int Id { get; set; }
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public DateTime DateCreated { get; set; } = DateTime.Now;
		public string Role { get; set; } = "Customer";
	}
}

