namespace WhatsNewInDotNet8.KeyedServices;

public interface IOrdersRetriever
{
    Marketplace Marketplace { get; }
    IReadOnlyCollection<Order> GetOrders(MarketplaceAccount account);
}