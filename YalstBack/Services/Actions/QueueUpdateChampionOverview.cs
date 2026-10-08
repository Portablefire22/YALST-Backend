namespace YalstBack.Services.Actions;

public class QueueUpdateChampionOverview : IQueuedAction
{
    public QueueUpdateChampionOverview(string puuid, IQueuedAction? parent = null)
    {
        Parent = parent;
        Puuid = puuid;
    }

    public IQueuedAction? Parent { get; set; }
    
    public string Puuid { get; set; }
    
    public void InvokeCallback()
    {
        Parent?.InvokeCallback();
    }
}