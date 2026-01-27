using FluentAssertions;
using NSubstitute;

namespace GameLibrary.Tests;

public class GameWorldTests
{
    [Fact]
    public void GetPlayerReport_PlayerExists_ReturnsExpectedReport()
    {
        // Arrange
        var player = new Player("Augusto", 10, new DateTime(2020, 1, 1));
        var stats = new PlayerStatistics
        {
            PlayerName = player.Name,
            GamesPlayed = 10,
            TotalScore = 1000
        };

        var statisticsServiceStub = Substitute.For<IPlayerStatisticsService>();
        statisticsServiceStub.GetPlayerStatistics(player.Name)
                             .Returns(stats);

        var expected = new PlayerReportDto(
            player.Name,
            player.Level,
            player.JoinDate,
            stats.GamesPlayed,
            stats.TotalScore,
            stats.TotalScore / stats.GamesPlayed
            );

        var sut = new GameWorld(statisticsServiceStub);

        // Act
        var actual = sut.GetPlayerReport(player);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void RecordPlayerGameWin_ValidPlayerAndScore_UpdatePlayerStatistics()
    {
        // Arrange
        var player = new Player("Augusto", 10, new DateTime(2020, 1, 1));

        var stats = new PlayerStatistics
        {
            PlayerName = player.Name,
            GamesPlayed = 10,
            TotalScore = 1000
        };

        var statisticsServerMock = Substitute.For<IPlayerStatisticsService>();
        statisticsServerMock.GetPlayerStatistics(player.Name).Returns(stats);

        var sut = new GameWorld(statisticsServerMock);

        // Act
        sut.RecordPlayerGameWin(player, 20);

        // Assert
        statisticsServerMock.Received().UpdatePlayerStatistics(Arg.Any<PlayerStatistics>());
        statisticsServerMock.Received().UpdatePlayerStatistics(Arg.Is<PlayerStatistics>(stats => 
                                            stats.PlayerName == player.Name &&
                                            stats.GamesPlayed == 11 &
                                            stats.TotalScore == 1020));

    }
}
