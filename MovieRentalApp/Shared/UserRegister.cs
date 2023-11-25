﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalApp.Shared
{
	public class UserRegister
	{
		[Required, EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required, StringLength(100, MinimumLength =6)]
		public string Password { get; set; } = string.Empty;

		[Compare("Password", ErrorMessage ="the passwords do not match")]
		public string ConfirmPassword { get; set; } = string.Empty;
	}
}

