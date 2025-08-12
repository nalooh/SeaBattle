using System.Data;

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

    /// <summary>Jméno hráče na tahu</summary>
    public string CurrentPlayerName
        => CurrentPlayer.Name;

    /// <summary>Vytvoří novou hru</summary>
    /// <param name="firstPlayerName">Jméno prvního hráče</param>
    /// <param name="secondPlayerName">Jméno druhého hráče</param>
    /// <param name="mapSize">Velikost hracího pole</param>
    internal Game(string firstPlayerName, string secondPlayerName, SeaMap firstPlayerMap, SeaMap secondPlayerMap)
    {
        FirstPlayer = new(firstPlayerName, firstPlayerMap);
        SecondPlayer = new(secondPlayerName, secondPlayerMap) { Opponent = FirstPlayer };
        FirstPlayer.Opponent = SecondPlayer;
        CurrentPlayer = FirstPlayer;
    }

    /// <summary>Palba do soupeřova hracího pole</summary>
    /// <param name="position">Pozice, do které hráč pálí</param>
    public FireResult Fire(Position position)
    {
        if (State == GameState.Over)
        {
            throw new Exception("Hra již skončila");
        }
        if (!CurrentPlayer.Opponent.Map.TryGetPosition(position, out SeaMapField? field))
        {
            throw new Exception("Palba mimo hrací plochu");
        }
        if (field.IsRevealed)
        {
            throw new Exception("Palba na již objevené pole");
        }

        field.Reveal();
        if (field.ContainsShip)
        {
            field.WarshipPart!.IsHit = true;
            if (field.WarshipPart.Warship.IsSunken)
            {
                if (CurrentPlayer.Opponent.Map.WarshipsLeft == 0)
                {
                    State = GameState.Over;
                    return FireResult.Win;
                }
                return FireResult.Sunk;
            }
            else
            {
                return FireResult.Hit;
            }
        }

        CurrentPlayer = CurrentPlayer.Opponent;
        State = State == GameState.FirstPlayerMove ? GameState.SecondPlayerMove : GameState.FirstPlayerMove;
        return FireResult.Miss;
    }

}
