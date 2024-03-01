namespace WhatsNewInDotNet8.KeyedServices;

public class OrdersRetrievalService(IEnumerable<IOrdersRetriever> ordersRetrievers) 
    : IOrdersRetrievalService
{
    public IReadOnlyCollection<Order> GetOrders(MarketplaceAccount account)
    {
        var retriever = ordersRetrievers.First(r => r.Marketplace == account.Marketplace);

        var orders = retriever.GetOrders(account);

        return orders;
    }
}