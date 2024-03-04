// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
namespace WhatsNewInDotNet8.Time;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}

public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}