using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Payments.Core.Domain;

public class Customer : Entity
{
    public long UserId { get; init; }
    public List<TourPurchaseToken>? TourPurchaseTokens { get; private set; }
    public long ShoppingCartId { get; init; }
    public int Xp { get; private set; }
    public int Level { get; private set; }  

    public Customer(long userId, long shoppingCartId)
    {
        UserId = userId;
        TourPurchaseTokens = new List<TourPurchaseToken>();
        ShoppingCartId = shoppingCartId;
        Xp = 0;
        Level = 1;
    }

    public bool OwnsTour(long tourId)
    {
        return TourPurchaseTokens != null && TourPurchaseTokens.Any(t => t.TourId == tourId);
    }

    public void AddTourPurchaseTokens(List<long> purchasedTourIds)
    {
        TourPurchaseTokens ??= new List<TourPurchaseToken>();

        foreach (var tourId in purchasedTourIds)
        {
            var token = new TourPurchaseToken(tourId);
            TourPurchaseTokens.Add(token);
        }
    }
}