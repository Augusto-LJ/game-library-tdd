namespace GameLibrary.Tests;

public class TreashureChestTests
{
    [Fact]
    public void CanOpenTest()
    {
        // Arrange
        bool isOpen = true;
        var chest = new TreasureChest(isOpen);

        // Act
        var result = chest.CanOpen(isOpen);

        // Assert
        Assert.True(result);
    }
}