namespace GameLibrary.Tests;

public class TreashureChestTests
{
    [Fact]
    public void CanOpen_ChestIsLockedAndHasKey_ReturnsTrue()
    {
        // Arrange
        bool isLocked = true;
        bool hasKey = true;
        var sut = new TreasureChest(isLocked);

        // Act
        var result = sut.CanOpen(hasKey);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CanOpen_ChestIsLockedAndHasNoKey_ReturnsFalse()
    {
        // Arrange
        bool isLocked = true;
        bool hasKey = false;
        var sut = new TreasureChest(isLocked);

        // Act
        var result = sut.CanOpen(hasKey);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CanOpen_ChestIsUnlockedAndHasKey_ReturnsTrue()
    {
        // Arrange
        bool isLocked = false;
        bool hasKey = true;
        var sut = new TreasureChest(isLocked);

        // Act
        var result = sut.CanOpen(hasKey);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CanOpen_ChestIsUnlockedAndHasNoKey_ReturnsTrue()
    {
        // Arrange
        bool isLocked = false;
        bool hasKey = false;
        var sut = new TreasureChest(isLocked);

        // Act
        var result = sut.CanOpen(hasKey);

        // Assert
        Assert.True(result);
    }
}