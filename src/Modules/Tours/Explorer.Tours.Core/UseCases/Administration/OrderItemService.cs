using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Administration
{
	public class OrderItemService : CrudService<OrderItemDto, OrderItem>, IOrderItemService
	{
		private readonly IOrderItemRepository _orderItemRepository;
		public OrderItemService(IOrderItemRepository repository, IMapper mapper) : base(repository, mapper)
		{
			_orderItemRepository = repository;
		}
	}
}
