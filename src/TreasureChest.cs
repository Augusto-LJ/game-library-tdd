namespace GameLibrary;

internal class TreasureChest(bool isLocked)
{
    internal bool IsLocked { get; set; } = isLocked;

    internal bool CanOpen(bool hasKey)
    {
        return !IsLocked || hasKey;
    }
}
