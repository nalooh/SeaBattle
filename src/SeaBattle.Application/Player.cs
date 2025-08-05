namespace SeaBattle.Application;

/// <summary>Třída obsahující všechno týkajícího se hráče</summary>
internal class Player
{
    /// <summary>Jméno hráče</summary>
    public string Name { get; }

    /// <summary>Hrací plocha hráče</summary>
    internal SeaMap Map { get; }

    /// <summary>Protihráč</summary>
    internal Player Opponent { get; set; }

    public Player(string name, int mapSize)
    {
        Name = name;
        Map = SeaMapGenerator.Generate(mapSize);
    }

}
