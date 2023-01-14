﻿using Silvernet.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Silvernet.Models {
	public class Product {

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "The name must be obligatory")]
		public string Marca { get; set; }

		[Required(ErrorMessage = "The name must be obligatory")]
		public string Modelo { get; set; }

		public string Description { get; set; }

		[ForeignKey("CategoryId")]
		[JsonIgnore]
		public int CategoryId { get; set; }

		public Category Category { get; set; }

		[Required(ErrorMessage = "The price must be obligatory")]
		public double Price { get; set; }

		[Required(ErrorMessage = "The Stock must be obligatory")]
		public int Stock { get; set; }

	}
}
