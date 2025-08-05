using Microsoft.AspNetCore.Mvc;
using SeaBattle.API.ViewModels;
using SeaBattle.Application;

namespace SeaBattle.API.Controllers;

[ApiController]
[Route("api/games")]
public class GameController(World world) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateGame(CreateGameModel model)
    {
        Game game = world.CreateGame(model.FirstPlayerName, model.SecondPlayerName, model.MapSize);
        return Ok(game.Id);
    }

}
