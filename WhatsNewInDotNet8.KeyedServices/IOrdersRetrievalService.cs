namespace WhatsNewInDotNet8.KeyedServices;

public interface IOrdersRetrievalService
{
    IReadOnlyCollection<Order> GetOrders(MarketplaceAccount account);
}