using BenchmarkDotNet.Running;
using Microsoft.Extensions.DependencyInjection;
using WhatsNewInDotNet8.KeyedServices;

var serviceProvider = new ServiceCollection()
    .AddKeyedSingleton<IOrdersRetriever, AmazonOrdersRetriever>(Marketplace.Amazon)
    .AddKeyedSingleton<IOrdersRetriever, EbayOrderRetriever>(Marketplace.Ebay)
    .AddSingleton<IOrdersRetrievalService, KeyedOrdersRetrievalService>()
    //.AddKeyedSingleton<IOrdersRetriever, AmazonOrdersRetriever>()
    //.AddKeyedSingleton<IOrdersRetriever, EbayOrderRetriever>()
    //.AddSingleton<IOrdersRetrievalService, OrdersRetrievalService>()
    .BuildServiceProvider();

var ordersRetrievalService = serviceProvider.GetRequiredService<IOrdersRetrievalService>();

var account = new MarketplaceAccount { Marketplace = Marketplace.Ebay };

var orders = ordersRetrievalService.GetOrders(account);

foreach (var order in orders)
{
    Console.WriteLine(order.Id);
}

BenchmarkRunner.Run<Benchmarks>();