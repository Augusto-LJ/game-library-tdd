namespace GameLibrary;

public class GameWorld(IPlayerStatisticsService playerStatisticsService)
{
    private readonly IPlayerStatisticsService playerStatisticsService = playerStatisticsService;

    public PlayerReportDto GetPlayerReport(Player player)
    {
        var stats = playerStatisticsService.GetPlayerStatistics(player.Name);
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
}
