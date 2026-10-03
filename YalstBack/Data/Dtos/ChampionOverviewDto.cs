namespace YalstBack.Data.Dtos;

public class ChampionOverviewDto
{
    public string ChampionName { get; set; }
    public int ChampionId { get; set; }
    public int Kills { get; set; }
    public int Deaths { get; set; }
    public int Assists { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int CreepsScore { get; set; }
    public long TimePlayed { get; set; }
}