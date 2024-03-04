using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace WhatsNewInDotNet8.KeyedServices;

public class EbayOrdersManager
{
    private readonly IOrdersRetriever _ordersRetriever;

    public EbayOrdersManager([FromKeyedServices(Marketplace.Ebay)] IOrdersRetriever ordersRetriever)
    {
        _ordersRetriever = ordersRetriever;
    }
}