namespace GameLibrary.Tests.Fakes;

internal class FakePlayerStatisticsService : IPlayerStatisticsService
{
    private readonly Dictionary<string, PlayerStatistics> _statistics = [];
    public PlayerStatistics GetPlayerStatistics(string playerName)
    {
        return _statistics[playerName];
    }

    public void UpdatePlayerStatistics(PlayerStatistics stats)
    {
        _statistics[stats.PlayerName] = stats;
    }
}
