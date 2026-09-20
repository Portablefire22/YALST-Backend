namespace YalstBack.Data.Dtos;

public class RankDto
{
    public long Time { get; set; }
    public string QueueType { get; set; }
    public string Tier { get; set; }
    public int Rank { get; set; }
    public int LeaguePoints { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
}