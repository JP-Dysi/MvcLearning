﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MvcLearning.Models
{
	public class MovieModel
	{
		public int Id { get; set; }

		[StringLength(60, MinimumLength = 3)]
		public string Title { get; set; }

		[Display(Name = "Release Datesplay")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime ReleaseDate { get; set; }

		[RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
		[Required]
		[StringLength(30)]
		public string Genre { get; set; }

		[Range(1, 9999)]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		[RegularExpression(@"[A-Z]+[a-zA-Z'\s]*$")]
		[StringLength(5)]
		public string Rating { get; set; }
	}

	public class MovieDbContext : DbContext
	{
		public DbSet<MovieModel> Movies { get; set; }
	}
}