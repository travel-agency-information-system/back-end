using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
	public class ShoppingCartDto
	{
		public long TouristId { get; set; }
		public List<OrderItemDto> Items { get; set; }
		public double Price { get; set; }
	}
}
