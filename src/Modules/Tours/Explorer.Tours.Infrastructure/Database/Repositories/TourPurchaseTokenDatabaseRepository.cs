using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourPurchaseTokenDatabaseRepository : CrudDatabaseRepository<TourPurchaseToken, ToursContext>, ITourPurchaseTokenRepository
    {
        public TourPurchaseTokenDatabaseRepository(ToursContext dbContext) : base(dbContext)
        {

        }

        //dodati po potrebi
    }
}
