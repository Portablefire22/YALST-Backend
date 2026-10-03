using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using YalstBack.Data.Dtos;

namespace YalstBack.Data.LeagueModels;

[PrimaryKey(nameof(Id))]
public class ChampionOverviewModel
{
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    /// <summary>
    /// When this overview was first tracked, used for separating by season timestamps
    /// </summary>
    public long LastUpdated { get; set; }
    public int QueueId { get; set; }
    public required SummonerModel Summoner { get; set; }
    public required string ChampionName { get; set; }
    public int ChampionId { get; set; }
    public int Kills { get; set; }
    public int Deaths { get; set; }
    public int Assists { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int CreepsScore { get; set; }
    public long TimePlayed { get; set; }

    public ChampionOverviewDto ToDto()
    {
        return new ChampionOverviewDto()
        {
            Assists =  Assists,
            CreepsScore = CreepsScore,
            Kills = Kills,
            Deaths = Deaths,
            Wins = Wins,
            Losses = Losses,
            ChampionName =  ChampionName,
            TimePlayed =  TimePlayed,
            ChampionId = ChampionId
        };
    }
}