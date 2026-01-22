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
        Assert.Equal(2, sut.Level);
        Assert.InRange(sut.Level, 2, 100);
    }

    [Fact]
    public void Greet_ValidGreeting_ReturnsGreetingWithName()
    {
        // Arrange
        Player sut = new("Augusto", 1, DateTime.Now);

        // Act
        var result = sut.Greet("Hello");

        // Assert
        Assert.Equal("Hello, Augusto!", result);
        Assert.Contains("Augusto", result);
        Assert.EndsWith("Augusto!", result);
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public void Constructor_OnNewInstance_SetsJoinDate()
    {
        // Arrange
        var currentDate = DateTime.Now;

        // Act
        Player sut = new("Augusto", 1, currentDate);

        // Assert
        Assert.Equal(currentDate, sut.JoinDate);
    }
}
