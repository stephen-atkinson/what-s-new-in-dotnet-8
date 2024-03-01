namespace WhatsNewInDotNet8.KeyedServices;

public class AmazonOrdersRetriever : IOrdersRetriever
{
    public Marketplace Marketplace => Marketplace.Amazon;
    
    public IReadOnlyCollection<Order> GetOrders(MarketplaceAccount account) => 
        new [] { new Order { Id = "14" } };
}