﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silvernet.Models.DTO;
using Silvernet.Models;
using Silvernet.Repository.IRepository;
using Silvernet.Utils;

namespace Silvernet.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ShoppingCartController : ControllerBase {

		private readonly IShoppingCartRepository _repository;
		private readonly IMapper _mapper;

		public ShoppingCartController(IShoppingCartRepository repository, IMapper mapper) {
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllShoppingCart() {
			try {
				var response = await _repository.GetAllShoppingCart();
				return StatusCode(302, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetOneShoppingCart(int id) {
			try {
				var response = await _repository.GetOneShoppingCart(id);
				return StatusCode(302, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		//[HttpGet("{status}")]
		//public async Task<IActionResult> GetAllByStatus(string status) {
		//	try {
		//		var response = await _repository.GetAllShoppingCart(status);
		//		return StatusCode(302, new { request_status = "successful", response = response });
		//	} catch (Exception ex) {
		//		return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
		//	}
		//}

		[HttpPost]
		public async Task<IActionResult> CreateShoppingCart([FromBody] ShoppingCartDTO shoppingCartDTO) {
			try {
				if (!ModelState.IsValid) throw new Exception(Messages.MOD_INCORRECT);
				var responseDTO = _mapper.Map<ShoppingCart>(shoppingCartDTO);
				var response = await _repository.CreateShoppingCart(responseDTO);
				//var response = _mapper.Map<ShoppingCartViewDTO>(responseViewDTO);
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[HttpPut]
		public async Task<IActionResult> UpdateShoppingCart([FromBody] ShoppingCartUpdateDTO shoppingCartUpdateDTO) {
			try {
				if (!ModelState.IsValid) throw new Exception(Messages.MOD_INCORRECT);
				var responseDTO = _mapper.Map<ShoppingCart>(shoppingCartUpdateDTO);
				var response = await _repository.UpdateShoppingCart(responseDTO);
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteShoppingCart(int id) {
			try {
				var response = await _repository.DeleteShoppingCart(id);
				return StatusCode(200, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

	}
}