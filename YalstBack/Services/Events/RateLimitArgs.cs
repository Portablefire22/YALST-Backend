namespace YalstBack.Services.Events;

public class RateLimitArgs
{
    public RateLimitArgs(int waitTime)
    {
        WaitTime = waitTime;
    }

    public int WaitTime { get; private set; }
}