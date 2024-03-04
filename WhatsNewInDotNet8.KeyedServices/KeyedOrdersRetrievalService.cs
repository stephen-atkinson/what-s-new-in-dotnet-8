using Microsoft.Extensions.DependencyInjection;
// ReSharper disable ConvertToPrimaryConstructor

namespace WhatsNewInDotNet8.KeyedServices;

public class KeyedOrdersRetrievalService : IOrdersRetrievalService
{
    private readonly IServiceProvider _serviceProvider;

    public KeyedOrdersRetrievalService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public IReadOnlyCollection<Order> GetOrders(MarketplaceAccount account)
    {
        var retriever = _serviceProvider.GetRequiredKeyedService<IOrdersRetriever>(account.Marketplace);

        var orders = retriever.GetOrders(account);

        return orders;
    }
}