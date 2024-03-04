
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton(TimeProvider.System)
    .BuildServiceProvider();

var timeProvider = serviceProvider.GetRequiredService<TimeProvider>();

timeProvider.CreateTimer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

void DoWork(object? state) { Console.WriteLine("Hi"); }