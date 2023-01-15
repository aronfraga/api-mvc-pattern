﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Silvernet.Utils;

namespace Silvernet.Models.DTO {
	public class ShoppingCartUpdateDTO {

		[Key]
		[Required(ErrorMessage = Messages.SHOC_MOD_ID)]
		public int Id { get; set; }

		[Required(ErrorMessage = Messages.SHOC_MOD_PROID)]
		public int ProductId { get; set; }

		[Required(ErrorMessage = Messages.SHOC_MOD_QTY)]
		public int Quantity { get; set; }

		[JsonIgnore]
		public double TotalPrice { get; set; }

		[JsonIgnore]
		public int? UserId { get; set; }

		[JsonIgnore]
		public string? UserEmail { get; set; }

		[JsonIgnore]
		public bool? Status { get; set; }

	}
}