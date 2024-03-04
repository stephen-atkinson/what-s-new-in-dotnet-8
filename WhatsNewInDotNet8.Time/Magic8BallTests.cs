using FluentAssertions;
using FluentAssertions.Extensions;
using Microsoft.Extensions.Time.Testing;
using Moq;

namespace WhatsNewInDotNet8.Time;

public class Magic8BallTests
{
    [Fact]
    public void IsItDonutTime_SetsCreated()
    {
        // Arrange
        var timeProvider = new FakeTimeProvider();
        var magic8Ball = new Magic8Ball(timeProvider);
        
        var utcNow = DateTime.UtcNow;
        timeProvider.SetUtcNow(utcNow);

        // Act
        var response = magic8Ball.IsItDonutTime();

        // Assert
        response.Created.Should().Be(utcNow);
    }

    [Theory]
    [InlineData(9, false)]
    [InlineData(12, true)]
    public void IsItDonutTime(int hour, bool isItDonutTime)
    {
        // Arrange
        var timeProvider = new FakeTimeProvider();
        var magic8Ball = new Magic8Ball(timeProvider);

        var utcNow = DateTime.UtcNow.At(hour, 0);
        timeProvider.SetUtcNow(utcNow);

        // Act
        var response = magic8Ball.IsItDonutTime();

        // Assert
        response.Value.Should().Be(isItDonutTime);
    }
}

// public class Magic8BallTests
// {
//     [Fact]
//     public void IsItDonutTime_SetsCreated()
//     {
//         // Arrange
//         var dateTimeProvider = new Mock<IDateTimeProvider>();
//         var magic8Ball = new Magic8Ball(dateTimeProvider.Object);
//         
//         var utcNow = DateTime.UtcNow;
//         dateTimeProvider.SetupGet(p => p.UtcNow).Returns(utcNow);
//
//         // Act
//         var response = magic8Ball.IsItDonutTime();
//
//         // Assert
//         response.Created.Should().Be(utcNow);
//     }
//
//     [Theory]
//     [InlineData(9, false)]
//     [InlineData(12, true)]
//     public void IsItDonutTime(int hour, bool isItDonutTime)
//     {
//         // Arrange
//         var dateTimeProvider = new Mock<IDateTimeProvider>();
//         var magic8Ball = new Magic8Ball(dateTimeProvider.Object);
//         
//         var utcNow = DateTime.UtcNow.At(hour, 0);
//         dateTimeProvider.SetupGet(p => p.UtcNow).Returns(utcNow);
//
//         // Act
//         var response = magic8Ball.IsItDonutTime();
//
//         // Assert
//         response.Value.Should().Be(isItDonutTime);
//     }
// }

// public class Magic8BallTests
// {
//     [Fact]
//     public void IsItDonutTime_SetsCreated()
//     {
//         // Arrange
//         var magic8Ball = new Magic8Ball();
//         var utcNow = DateTime.UtcNow;
//
//         // Act
//         var response = magic8Ball.IsItDonutTime();
//
//         // Assert
//         response.Created.Should().BeCloseTo(utcNow, TimeSpan.FromMilliseconds(1));
//     }
//
//     [Fact]
//     public void IsItDonutTime_ReturnsTrue()
//     {
//         // Arrange
//         var magic8Ball = new Magic8Ball();
//
//         // Act
//         var response = magic8Ball.IsItDonutTime();
//
//         // Assert
//         response.Value.Should().BeTrue();
//     }
// }