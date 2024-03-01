namespace WhatsNewInDotNet8.KeyedServices;

public class EbayOrderRetriever : IOrdersRetriever
{
    public Marketplace Marketplace => Marketplace.Ebay;
    
    public IReadOnlyCollection<Order> GetOrders(MarketplaceAccount account) => 
        new [] { new Order { Id = "A111" } };
}