namespace GameLibrary;

public class TreasureChest(bool isLocked)
{
    public bool IsLocked { get; set; } = isLocked;

    public bool CanOpen(bool hasKey)
    {
        if (IsLocked && !hasKey)
            return false;

        else
            return true;
    }
}
