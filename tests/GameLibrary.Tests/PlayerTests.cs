using FluentAssertions;

namespace GameLibrary.Tests;

public class PlayerTests
{
    [Fact]
    public void IncreaseLevel_WhenCalled_HasExpectedLevel()
    {
        // Arrange
        Player sut = new("Augusto", 1, DateTime.Now);

        // Act
        sut.IncreaseLevel();

        // Assert
        sut.Level.Should().Be(2);
        sut.Level.Should().BeGreaterThan(1);
        sut.Level.Should().BeGreaterThanOrEqualTo(2);
        sut.Level.Should().BePositive();
        sut.Level.Should().NotBe(1);
        sut.Level.Should().BeInRange(2, 100);
    }

    [Fact]
    public void Greet_ValidGreeting_ReturnsGreetingWithName()
    {
        // Arrange
        Player sut = new("Augusto", 1, DateTime.Now);

        // Act
        var result = sut.Greet("Hello");

        // Assert
        result.Should().Be("Hello, Augusto!");
        result.Should().Contain("Augusto");
        result.Should().EndWith("Augusto!");
        result.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void Constructor_OnNewInstance_SetsJoinDate()
    {
        // Arrange
        var currentDate = DateTime.Now;

        // Act
        Player sut = new("Augusto", 1, currentDate);

        // Assert
        sut.JoinDate.Should().Be(currentDate);
        sut.JoinDate.Should().BeCloseTo(currentDate, TimeSpan.FromMilliseconds(500));
        sut.JoinDate.Should().BeWithin(TimeSpan.FromMilliseconds(500)).Before(currentDate);
    }
}
