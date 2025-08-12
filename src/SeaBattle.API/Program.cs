using Microsoft.AspNetCore.Http.HttpResults;
using Scalar.AspNetCore;
using Serilog;
using SeaBattle.API.ViewModels;
using SeaBattle.Application;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(Path.Combine("logs", "SeaBattle.log"), rollingInterval: RollingInterval.Day, retainedFileTimeLimit: TimeSpan.FromDays(14))
    .CreateLogger();

try
{
    Log.Information("Application started.");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddOpenApi();

    builder.Services.AddSingleton<World>();

    builder.Host.UseSerilog();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
    }

    app.UseHttpsRedirection();

    app.MapPost("api/games", Ok<GameViewModel> (CreateGameModel model, World world) =>
    {
        Game game = world.CreateGame(model.FirstPlayerName, model.SecondPlayerName, model.MapSize);
        return TypedResults.Ok(new GameViewModel(game.Id, game.State.ToString(), game.CurrentPlayerName));
    });

    app.MapPost("api/games/{id:guid}/moves", Results<Ok<FireResultModel>, NotFound> (Guid id, FireModel model, World world) =>
    {
        Game? game = world.GetGame(id);
        if (game == null) return TypedResults.NotFound();

        FireResult result = game.Fire(new Position(model.X, model.Y));
        return TypedResults.Ok(new FireResultModel(result.ToString(), game.State.ToString(), game.CurrentPlayerName));
    });

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application exited unexpectally.");
}
finally
{
    Log.CloseAndFlush();
}
