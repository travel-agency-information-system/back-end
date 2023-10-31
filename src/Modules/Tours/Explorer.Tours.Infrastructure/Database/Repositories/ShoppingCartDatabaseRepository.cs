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
	public class ShoppingCartDatabaseRepository : CrudDatabaseRepository<ShoppingCart, ToursContext>, IShoppingCartRepository
	{
		public ShoppingCartDatabaseRepository(ToursContext dbContext) : base(dbContext)
		{ }

		public bool ShoppingCartExists(int touristId)
		{
			return DbContext.ShoppingCarts.Any(sc => sc.TouristId == touristId);
		}

		public ShoppingCart GetShoppingCart(int touristId)
		{
			return DbContext.ShoppingCarts.FirstOrDefault(sc => sc.TouristId == touristId);
		}
	}
}
