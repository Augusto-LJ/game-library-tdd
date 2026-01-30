namespace GameLibrary;

public class QuestLog(string inicialQuest)
{
    public List<string> Quests { get; private set; } = [inicialQuest];

    public bool AddQuest(string quest)
    {
        Quests.Add(quest);
        return true;
    }
}
