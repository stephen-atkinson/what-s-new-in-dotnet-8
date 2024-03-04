// ReSharper disable ConvertToPrimaryConstructor
// ReSharper disable UnusedType.Global
namespace WhatsNewInDotNet8.KeyedServices;

public class OrdersRetrievalService : IOrdersRetrievalService
{
    private readonly IEnumerable<IOrdersRetriever> _ordersRetrievers;

    public OrdersRetrievalService(IEnumerable<IOrdersRetriever> ordersRetrievers)
    {
        _ordersRetrievers = ordersRetrievers;
    }
    
    public IReadOnlyCollection<Order> GetOrders(MarketplaceAccount account)
    {
        var retriever = _ordersRetrievers.First(r => r.Marketplace == account.Marketplace);

        var orders = retriever.GetOrders(account);

        return orders;
    }
}