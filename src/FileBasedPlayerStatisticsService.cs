using System.Text.Json;

namespace GameLibrary;

public class FileBasedPlayerStatisticsService(string filepath) : IPlayerStatisticsService
{
    private readonly string filePath = filepath;

    public PlayerStatistics GetPlayerStatistics(string playerName)
    {
        var statsDictionary = ReadStatisticsFromFile();

        if (statsDictionary.TryGetValue(playerName, out PlayerStatistics? value))
        {
            return value;
        }

        return new PlayerStatistics { PlayerName = playerName };
    }

    public void UpdatePlayerStatistics(PlayerStatistics stats)
    {
        var statsDictionary = ReadStatisticsFromFile();
        statsDictionary[stats.PlayerName] = stats;
        WriteStatisticsToFile(statsDictionary);
    }

    private Dictionary<string, PlayerStatistics> ReadStatisticsFromFile()
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Statistics file not found", filePath);
        }

        var json = File.ReadAllText(filePath);
        var statistics = JsonSerializer.Deserialize<Dictionary<string, PlayerStatistics>>(json);
        return statistics ?? [];
    }

    private void WriteStatisticsToFile(Dictionary<string, PlayerStatistics> statsDictionary)
    {

    }
}
