using Microsoft.AspNetCore.Mvc;
using YalstBack.Data.Dtos;
using YalstBack.Services;

namespace YalstBack.Controllers;

[Route("[controller]")]
[ApiController]
public class MatchesController : Controller
{
    private RiotClient _riotClient;

    public MatchesController(RiotClient riotClient)
    {
        _riotClient = riotClient;
    }
    

    [HttpGet()]
    public async Task<ActionResult<MatchDto[]>> GetMatches([FromQuery] string [] puuid, [FromQuery] long? lastTimestamp)
    {
        var matches = await _riotClient.GetMatches(puuid, lastTimestamp: lastTimestamp);
        return Ok(matches);
    }

    [HttpGet("{matchId}/participants")]
    public async Task<ActionResult<MatchParticipantDto[]>> GetMatchParticipants(string matchId)
    {
        var participants = await _riotClient.GetMatchParticipants(matchId);
        if (participants.Length == 0) return NotFound();
        return Ok(participants.Select(x => x.ToDto()).ToArray());
    } 
}