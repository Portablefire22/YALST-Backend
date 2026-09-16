namespace YalstBack.Services.Actions;

public interface IQueuedAction
{
    public IQueuedAction? Parent { get; set; }

    public void InvokeCallback();
}