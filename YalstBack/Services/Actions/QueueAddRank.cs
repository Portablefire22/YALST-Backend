using YalstBack.Data.LeagueModels;

namespace YalstBack.Services.Actions;

public class QueueAddRank : IQueuedAction
{
   public QueueAddRank(SummonerModel summoner, IQueuedAction? parent = null)
   {
      Summoner = summoner;
      Parent = parent;
   }

   public SummonerModel Summoner { get; set; }
   public IQueuedAction? Parent { get; set; }
   public void InvokeCallback()
   {
      Parent?.InvokeCallback();
   }
}