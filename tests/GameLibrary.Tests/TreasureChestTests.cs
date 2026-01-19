namespace GameLibrary.Tests;

public class TreasureChestTests : IDisposable
{
    private readonly Stack<TreasureChest> chests;

    public TreasureChestTests()
    {
        chests = new();
    }

    public void Dispose()
    {
        chests.Pop();
        Assert.Empty(chests);
    }

    [Fact]
    public void CanOpen_ChestIsLockedAndHasKey_ReturnsTrue()
    {
        // Arrange
        bool isLocked = true;
        bool hasKey = true;
        var sut = new TreasureChest(isLocked);
        chests.Push(sut);

        // Act
        var result = sut.CanOpen(hasKey);

        // Assert
        Assert.True(result);
        Assert.Single(chests);
    }

    [Fact]
    public void CanOpen_ChestIsLockedAndHasNoKey_ReturnsFalse()
    {
        // Arrange
        bool isLocked = true;
        bool hasKey = false;
        var sut = new TreasureChest(isLocked);
        chests.Push(sut);

        // Act
        var result = sut.CanOpen(hasKey);

        // Assert
        Assert.False(result);
        Assert.Single(chests);
    }

    [Fact]
    public void CanOpen_ChestIsUnlockedAndHasKey_ReturnsTrue()
    {
        // Arrange
        bool isLocked = false;
        bool hasKey = true;
        var sut = new TreasureChest(isLocked);
        chests.Push(sut);

        // Act
        var result = sut.CanOpen(hasKey);

        // Assert
        Assert.True(result);
        Assert.Single(chests);
    }

    [Fact]
    public void CanOpen_ChestIsUnlockedAndHasNoKey_ReturnsTrue()
    {
        // Arrange
        bool isLocked = false;
        bool hasKey = false;
        var sut = new TreasureChest(isLocked);
        chests.Push(sut);

        // Act
        var result = sut.CanOpen(hasKey);

        // Assert
        Assert.True(result);
        Assert.Single(chests);
    }
}