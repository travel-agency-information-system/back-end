using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class TourPurchaseToken: Entity
    {
        public long TouristId { get; init;}
        public long TourId { get; init;}
        public string Token { get; init;}

        public TourPurchaseToken()
        {

        }

        public TourPurchaseToken(long toruistId, long tourId)
        {
            this.TouristId = toruistId;
            this.TourId = tourId;
            this.Token = ""; // za sad ovako

        }

    }
}
