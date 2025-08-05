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
        return Ok(new GameViewModel(game.Id, game.State.ToString(), game.CurrentPlayerName));
    }

    [HttpPost("{id:guid}/moves")]
    public IActionResult Fire(Guid id, FireModel model)
    {
        Game? game = world.GetGame(id);
        if (game == null) return NotFound();

        FireResult result = game.Fire(new Position(model.X, model.Y));
        return Ok(new FireResultModel(result.ToString(), game.State.ToString(), game.CurrentPlayerName));
    }

}
