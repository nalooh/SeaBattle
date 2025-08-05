namespace SeaBattle.Application;

/// <summary>Aktuální stav hry</summary>
public enum GameState
{
    /// <summary>Na tahu je první hráč</summary>
    FirstPlayerMove,
    /// <summary>Na tahu je druhý hráč</summary>
    SecondPlayerMove,
    /// <summary>Hra skončia</summary>
    Over,

}
