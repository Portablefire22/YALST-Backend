using YalstBack.Data.Dtos.MatchHistory;
using YalstBack.Data.LeagueModels;

namespace YalstBack.Services.Actions;

public class QueueMatchParticipant : IQueuedAction
{
    public string Puuid { get; private set; }
    public ParticipantDto MatchParticipant { get; private set; }
    public MatchModel MatchModel { get; private set; }

    public QueueMatchParticipant(string puuid, ParticipantDto matchParticipant, MatchModel matchModel, IQueuedAction? parent = null)
    {
        Puuid = puuid;
        MatchParticipant = matchParticipant;
        MatchModel = matchModel;
        Parent = parent;
    }

    public IQueuedAction? Parent { get; set; }
    public void InvokeCallback()
    {
        Parent?.InvokeCallback();
    }
}