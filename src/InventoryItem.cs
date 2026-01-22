namespace GameLibrary;

public class InventoryItem(int id, string name, string description)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string Description { get; private set; } = description;
}
