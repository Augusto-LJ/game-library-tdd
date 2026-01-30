using FluentAssertions;

namespace GameLibrary.Tests;
public class QuestLogTests
{
    [Fact]
    public void AddQuest_WhenCalled_AddsQuestLog()
    {
        // Arrange
        var sut = new QuestLog("Initial Quest");

        // Act
        var result = sut.AddQuest("Second Quest");

        // Assert
        result.Should().Be(true);
        sut.Quests.Should().HaveCount(2);
        sut.Quests.Should().Contain("Second Quest");
    }
}
