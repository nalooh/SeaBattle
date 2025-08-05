namespace SeaBattle.Application;

/// <summary>Třída obsahující vše potřebné ke hře</summary>
public class Game
{
    /// <summary>Identifikace hry pro vyhledávání</summary>
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>Aktuální stav této hry</summary>
    public GameState State { get; internal set; } = GameState.FirstPlayerMove;

    /// <summary>První hráč</summary>
    internal Player FirstPlayer { get; }

    /// <summary>Druhý hráč</summary>
    internal Player SecondPlayer { get; }

    /// <summary>Hráč, který je právě na tahu</summary>
    internal Player CurrentPlayer { get; set; }

    internal Game(string firstPlayerName, string secondPlayerName, int mapSize)
    {
        FirstPlayer = new(firstPlayerName, mapSize);
        SecondPlayer = new(secondPlayerName, mapSize) { Opponent = FirstPlayer };
        FirstPlayer.Opponent = SecondPlayer;
        CurrentPlayer = FirstPlayer;
    }

}
