using Microsoft.AspNetCore.Mvc;

namespace YalstBack.Controllers;

[ApiController]
[Route("[controller]")]
public class SummonerController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Ok("Hello, World!");
    }
}