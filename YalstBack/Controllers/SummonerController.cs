using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using YalstBack.Data.Dtos;
using YalstBack.Data.LeagueModels;
using YalstBack.Services;
using YalstBack.Services.Actions;

namespace YalstBack.Controllers;


#if DEBUG
[EnableCors("_localhostOrigin")]
#else
[EnableCors("_kittenOrigin")]
#endif
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

    [HttpGet("{puuid}/rank")]
    public async Task<ActionResult<Dictionary<string, RankedModel[]>>> GetSummonerRankedHistory(string puuid)
    {
        var summoner = await _riotClient.SummonerModelByPuuid(puuid);
        if (summoner == null) return NotFound();
        var history = await _riotClient.GetRankedHistory(summoner);
        return Ok(history);
    }

    [HttpPatch("{puuid}")]
    public IActionResult UpdateSummoner(string puuid)
    {
        _riotClient.QueueAction(new QueueUpdateSummoner(puuid, null));
        return Ok();
    }

    [HttpGet("{puuid}/is-updating")]
    public ActionResult<bool> GetSummonerStatus(string puuid)
    {
        return _riotClient.InQueue(puuid);
    }
}