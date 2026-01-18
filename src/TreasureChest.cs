namespace GameLibrary;

public class TreasureChest(bool isLocked)
{
    public bool IsLocked { get; set; } = isLocked;

    public bool CanOpen(bool hasKey)
    {
        return !IsLocked || hasKey;
    }
}
