using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Tour
{
	[Authorize(Policy = "touristPolicy")]
	[Route("api/tourist/shopping-cart")]
	public class ShoppingCartController : BaseApiController
	{
		private readonly IShoppingCartService _shoppingCartService;

		public ShoppingCartController(IShoppingCartService shoppingCartService)
		{
			_shoppingCartService = shoppingCartService;
		}

		[HttpGet]
		public ActionResult<PagedResult<ShoppingCartDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
		{
			var result = _shoppingCartService.GetPaged(page, pageSize);
			return CreateResponse(result);
		}

		[HttpPost]
		public ActionResult<ShoppingCartDto> Create([FromBody] ShoppingCartDto shoppingCart)
		{
			var result = _shoppingCartService.Create(shoppingCart);
			return CreateResponse(result);
		}

		[HttpPut("{id:int}")]
		public ActionResult<ShoppingCartDto> Update([FromBody] ShoppingCartDto shoppingCart)
		{
			var result = _shoppingCartService.Update(shoppingCart);
			return CreateResponse(result);
		}

		[HttpDelete("{id:int}")]
		public ActionResult Delete(int id)
		{
			var result = _shoppingCartService.Delete(id);
			return CreateResponse(result);
		}
	}
}
