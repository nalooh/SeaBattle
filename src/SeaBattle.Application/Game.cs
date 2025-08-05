namespace SeaBattle.Application;

public class Game
{
    public Guid Id { get; } = Guid.NewGuid();

    public GameState State { get; internal set; }

    public Game(string firstPlayerName, string secondPlayerName, int mapSize)
    {

    }

}
