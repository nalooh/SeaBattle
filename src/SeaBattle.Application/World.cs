namespace SeaBattle.Application;

/// <summary>Třída obsahující probíhající hry</summary>
public class World
{
    /// <summary>Minimální velikost hrací plochy</summary>
    private const int MapMinSize = 10;

    /// <summary>Maximální velikost hrací plochy</summary>
    private const int MapMaxSize = 20;

    private readonly Dictionary<Guid, Game> games = [];

    /// <summary>Založí novou hru</summary>
    /// <param name="firstPlayerName">Jméno prvního hráče</param>
    /// <param name="secondPlayerName">Jméno druhého hráče</param>
    /// <param name="mapSize">Velikost hrací plochy</param>
    public Game CreateGame(string firstPlayerName, string secondPlayerName, int mapSize)
    {
        if (mapSize < MapMinSize || mapSize > MapMaxSize)
        {
            throw new Exception($"Velikost hrací plochy musí být mezi {MapMinSize} a {MapMaxSize}.");
        }
        Game newGame = new(firstPlayerName, secondPlayerName, mapSize);
        games.Add(newGame.Id, newGame);
        return newGame;
    }

    /// <summary>Vyhledá hru podle ID</summary>
    /// <param name="GameId">ID hledané hry</param>
    public Game? GetGame(Guid GameId)
    {
        return games.TryGetValue(GameId, out Game? game) ? game : null;
    }

}
