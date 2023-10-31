using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
	public class ShoppingCart : Entity
	{
		public long TouristId { get; init; }
		public List<OrderItem> Items { get; init; }
		public double Price { get; init; }
		public ShoppingCart()
		{
			// Inicijalizacija po potrebi
		}

		public ShoppingCart(long touristId, List<OrderItem> items) 
		{ 
			TouristId = touristId;
			Items = items;
			// logika za racunanje ukupne cene korpe
		}
	}
}
