// ReSharper disable UnusedMember.Global
// ReSharper disable ArrangeObjectCreationWhenTypeEvident
// ReSharper disable UnusedType.Global

using System.Diagnostics.CodeAnalysis;
// ReSharper disable ConvertToPrimaryConstructor

namespace WhatsNewInDotNet8.Time;

[SuppressMessage("Performance", "CA1822:Mark members as static")]

public class Magic8Ball
{
    private readonly TimeProvider _timeProvider;

    public Magic8Ball(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public DonutTimeResponse IsItDonutTime() => new DonutTimeResponse
    {
        Created = _timeProvider.GetUtcNow().DateTime,
        Value = _timeProvider.GetUtcNow().DateTime.Hour is >= 12 and <= 14
    };
}

// public class Magic8Ball
// {
//     private readonly IDateTimeProvider _dateTimeProvider;
//
//     public Magic8Ball(IDateTimeProvider dateTimeProvider)
//     {
//         _dateTimeProvider = dateTimeProvider;
//     }
//
//     public DonutTimeResponse IsItDonutTime() => new DonutTimeResponse
//     {
//         Created = _dateTimeProvider.UtcNow,
//         Value = _dateTimeProvider.UtcNow.Hour is >= 12 and <= 14
//     };
// }


// public class Magic8Ball
// {
//     public DonutTimeResponse IsItDonutTime() => new DonutTimeResponse
//     {
//         Created = DateTime.UtcNow,
//         Value = DateTime.UtcNow.Hour is >= 12 and <= 14
//     };
// }