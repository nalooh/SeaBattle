namespace SeaBattle.Application;

public class World
{
    private readonly Dictionary<Guid, Game> games = [];

    public Game CreateGame(string firstPlayerName, string secondPlayerName, int mapSize)
    {
        Game newGame = new(firstPlayerName, secondPlayerName, mapSize);
        games.Add(newGame.Id, newGame);
        return newGame;
    }

    public Game? GetGame(Guid GameId)
    {
        return games.TryGetValue(GameId, out Game? game) ? game : null;
    }

}
