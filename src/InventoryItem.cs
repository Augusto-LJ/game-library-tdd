namespace GameLibrary;

public class InventoryItem(string description)
{
    public string Description { get; private set; } = description;
}
