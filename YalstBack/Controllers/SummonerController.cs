using Microsoft.AspNetCore.Mvc;
using YalstBack.Data.Dtos;
using YalstBack.Data.LeagueModels;
using YalstBack.Services;

namespace YalstBack.Controllers;

[ApiController]
[Route("[controller]")]
public class SummonerController : Controller
{

    private RiotClient _riotClient;

    public SummonerController(RiotClient riotClient)
    {
        _riotClient = riotClient;
    }

    [HttpGet()]
    public async Task<ActionResult<SummonerDto>> GetSummoner([FromQuery] string? gameName, [FromQuery] string? tagLine, [FromQuery] string? region, [FromQuery] string? puuid)
    {
        SummonerModel? summoner;
        if (puuid != null)
        {
            summoner = await _riotClient.SummonerModelByPuuid(puuid,  region);
            if (summoner == null) return NotFound();
            return Ok(summoner.ToDto());
        }
        if (gameName == null ||  tagLine == null || region == null ) return BadRequest();
        summoner = await _riotClient.SummonerModelByRiotId(gameName, tagLine, region);
        if (summoner == null) return NotFound();
        return Ok(summoner.ToDto());
    }
}