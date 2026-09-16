using Microsoft.AspNetCore.Mvc;
using YalstBack.Data.Dtos;
using YalstBack.Services;

namespace YetAnotherLeagueStatTracker.Controllers;

[Route("[controller]")]
[ApiController]
public class MatchesController : Controller
{
    private RiotClient _riotClient;

    public MatchesController(RiotClient riotClient)
    {
        _riotClient = riotClient;
    }
    

    [HttpGet("GetMatches")]
    public async Task<ActionResult<MatchDto[]>> GetMatches([FromQuery] string [] puuid)
    {
        var matches = await _riotClient.GetMatches(puuid);
        return Ok(matches);
    }

    [HttpGet("GetMatchParticipants")]
    public async Task<ActionResult<MatchParticipantDto[]>> GetMatchParticipants([FromQuery] string matchId)
    {
        var participants = await _riotClient.GetMatchParticipants(matchId);
        if (participants.Length == 0) return NotFound();
        return Ok(participants.Select(x => x.ToDto()).ToArray());
    } 
}