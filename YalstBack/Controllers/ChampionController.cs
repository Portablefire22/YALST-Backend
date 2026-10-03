using Microsoft.AspNetCore.Mvc;
using YalstBack.Data.Dtos;
using YalstBack.Services;

namespace YalstBack.Controllers;

[ApiController]
[Route("[controller]")]
public class ChampionController : Controller
{
    
    private RiotClient _riotClient;

    public ChampionController(RiotClient riotClient)
    {
        _riotClient = riotClient;
    }

    /// <summary>
    /// Retrieves champion overview for requests puuid, summarising stats for all champions
    /// </summary>
    /// <param name="puuid">List of puuids to summarise champions for</param>
    /// <returns>Lists of champion overviews, separated by gamemode</returns>
    [HttpGet("overview")]
    public async Task<ActionResult<Dictionary<int, ChampionOverviewDto[]>>> GetOverview([FromQuery] string[] puuid)
    {
        if (puuid.Length == 0)
        {
            return BadRequest();
        }

        var overview = await _riotClient.GetChampionOverviews(puuid);
        
        Dictionary<int, ChampionOverviewDto[]> result = [];

        foreach (var (key, overviews) in overview)
        {
            result[key] = [.. overviews.Select(x => x.ToDto())];
        }
        return Ok(result);
    }
}