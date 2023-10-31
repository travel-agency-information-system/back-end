using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Tour
{
	[Authorize(Policy = "touristPolicy")]
	[Route("api/tourist/order-item")]
	public class OrderItemController : BaseApiController
	{
		private readonly IOrderItemService _orderItemService;

		public OrderItemController(IOrderItemService orderItemService)
		{
			_orderItemService = orderItemService;
		}

		[HttpGet]
		public ActionResult<PagedResult<OrderItemDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
		{
			var result = _orderItemService.GetPaged(page, pageSize);
			return CreateResponse(result);
		}

		[HttpPost]
		public ActionResult<OrderItemDto> Create([FromBody] OrderItemDto orderItem)
		{
			var result = _orderItemService.Create(orderItem);
			return CreateResponse(result);
		}

		[HttpPut("{id:int}")]
		public ActionResult<OrderItemDto> Update([FromBody] OrderItemDto orderItem)
		{
			var result = _orderItemService.Update(orderItem);
			return CreateResponse(result);
		}

		[HttpDelete("{id:int}")]
		public ActionResult Delete(int id)
		{
			var result = _orderItemService.Delete(id);
			return CreateResponse(result);
		}
	}
}
