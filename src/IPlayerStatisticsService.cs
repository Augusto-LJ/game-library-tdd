namespace GameLibrary;

public interface IPlayerStatisticsService
{
    public PlayerStatistics GetPlayerStatistics(string playerName);
    public void UpdatePlayerStatistics(PlayerStatistics stats);
}
