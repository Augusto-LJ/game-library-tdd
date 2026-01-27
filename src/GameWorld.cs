namespace GameLibrary;

public class GameWorld(IPlayerStatisticsService playerStatisticsService)
{
    private readonly IPlayerStatisticsService _playerStatisticsService = playerStatisticsService;

    public PlayerReportDto GetPlayerReport(Player player)
    {
        var stats = _playerStatisticsService.GetPlayerStatistics(player.Name);
        double averageScore = stats.GamesPlayed == 0 ? 0 : stats.TotalScore / stats.GamesPlayed;

        return new PlayerReportDto(
            player.Name,
            player.Level,
            player.JoinDate,
            stats.GamesPlayed,
            stats.TotalScore,
            averageScore
        );
    }

    public void RecordPlayerGameWin(Player player, int score)
    {
        var stats = _playerStatisticsService.GetPlayerStatistics(player.Name);
        stats.TotalScore += score;
        stats.GamesPlayed++;
        _playerStatisticsService.UpdatePlayerStatistics(stats);
    }
}
