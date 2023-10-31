using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
	public class OrderItemDatabaseRepository : CrudDatabaseRepository<OrderItem, ToursContext>, IOrderItemRepository
	{
		public OrderItemDatabaseRepository(ToursContext dbContext) : base(dbContext)
		{ }
	}
}
