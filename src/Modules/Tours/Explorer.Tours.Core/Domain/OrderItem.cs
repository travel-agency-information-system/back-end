using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
	public class OrderItem : Entity
	{
		public long TourId { get; init; }
		public String TourName { get; init; }
		public double Price { get; init; }
		// id korpe kojoj stavka pripada 

		public OrderItem(long tourId, String tourName, double price) 
		{
			TourId = tourId; 
			TourName = tourName; 
			Price = price;
		}
	}
}
