using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace WhatsNewInDotNet8.KeyedServices;

public class Benchmarks
{
    private IServiceProvider _serviceProvider;
    
    [GlobalSetup(Targets = [nameof(Singleton), nameof(KeyedSingleton)])]
    public void SetupSingleton()
    {
        _serviceProvider = new ServiceCollection()
            .AddKeyedSingleton<IOrdersRetriever, EbayOrderRetriever>(Marketplace.Ebay)
            .AddSingleton<IOrdersRetriever, EbayOrderRetriever>()
            .BuildServiceProvider();
    }

    [GlobalSetup(Targets = [nameof(Transient), nameof(KeyedTransient)])]
    public void SetupTransient()
    {
        _serviceProvider = new ServiceCollection()
            .AddKeyedTransient<IOrdersRetriever, EbayOrderRetriever>(Marketplace.Ebay)
            .AddTransient<IOrdersRetriever, EbayOrderRetriever>()
            .BuildServiceProvider();
    }

    [Benchmark]
    public void Singleton() => 
        _serviceProvider.GetServices<IOrdersRetriever>().First(r => r.Marketplace == Marketplace.Ebay);

    [Benchmark]
    public void KeyedSingleton() => 
        _serviceProvider.GetRequiredKeyedService<IOrdersRetriever>(Marketplace.Ebay);
    
    [Benchmark]
    public void Transient() => 
        _serviceProvider.GetServices<IOrdersRetriever>().First(r => r.Marketplace == Marketplace.Ebay);
    
    [Benchmark]
    public void KeyedTransient() => 
        _serviceProvider.GetRequiredKeyedService<IOrdersRetriever>(Marketplace.Ebay);
}