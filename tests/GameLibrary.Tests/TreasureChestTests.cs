using Xunit.Abstractions;

namespace GameLibrary.Tests;

public class TreasureChestTests : IDisposable
{
    private readonly Stack<TreasureChest> chests;
    private readonly ITestOutputHelper output;

    public TreasureChestTests(ITestOutputHelper output)
    {
        chests = new();
        this.output = output;
        output.WriteLine($"Initial chest count: {chests.Count}");
    }

    public void Dispose()
    {
        chests.Pop();
        Assert.Empty(chests);
        output.WriteLine($"Final chest count: {chests.Count}");
    }

    [Theory]
    [InlineData(true, true, true)]
    [InlineData(true, false, false)]
    [InlineData(false, true, true)]
    [InlineData(false, false, true)]
    public void CanOpen_WhenCalled_ReturnsExpectedOutcome(bool isLocked, bool hasKey, bool expected)
    {
        // Arrange
        var sut = new TreasureChest(isLocked);
        chests.Push(sut);
        output.WriteLine($"Chest count: {chests.Count}");

        // Act
        var actual = sut.CanOpen(hasKey);

        // Assert
        Assert.Equal(expected, actual);
        Assert.Single(chests);
    }
}