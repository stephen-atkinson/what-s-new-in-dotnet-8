using Microsoft.Extensions.DependencyInjection;

namespace WhatsNewInDotNet8.KeyedServices;

public class EbayOrdersManager(
    [FromKeyedServices(Marketplace.Ebay)] IOrdersRetriever ordersRetriever)
{
}