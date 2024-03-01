using Microsoft.Extensions.DependencyInjection;

namespace WhatsNewInDotNet8.KeyedServices;

public class KeyedOrdersRetrievalService(IServiceProvider serviceProvider) 
    : IOrdersRetrievalService
{
    public IReadOnlyCollection<Order> GetOrders(MarketplaceAccount account)
    {
        var retriever = serviceProvider.GetRequiredKeyedService<IOrdersRetriever>(account.Marketplace);

        var orders = retriever.GetOrders(account);

        return orders;
    }
}