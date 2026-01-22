using FluentAssertions;

namespace GameLibrary.Tests;

public class PlayerExtensionsTests
{
    [Fact]
    public void ToDto_WhenCalled_MapsProperties()
    {
        // Arrange
        var sut = new Player("Augusto", 1, DateTime.Now);
        var item = new InventoryItem(101, "Sword", "A sharp blade");
        sut.AddItemToInventory(item);

        // Act
        var dto = sut.ToDto();

        // Assert
        dto.Should().BeEquivalentTo(sut, options => options
                        .ExcludingMissingMembers());
    }
}
