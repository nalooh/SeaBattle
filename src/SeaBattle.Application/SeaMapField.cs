namespace SeaBattle.Application;

/// <summary>Pole na hrací ploše</summary>
internal class SeaMapField
{
    /// <summary>Odkaz na hrací plochu, na které se pole nachází</summary>
    private readonly SeaMap map;

    /// <summary>Pozice pole na hrací ploše</summary>
    private readonly Position position;

    /// <summary>Odkaz na loď</summary>
    internal WarshipPart? WarshipPart { get; set; }

    /// <summary>Informace o tom, jestli již bylo pole objeveno</summary>
    public bool IsRevealed { get; set; }

    /// <summary>Informac o tom, jestli pole obsahuje loď</summary>
    public bool ContainsShip
        => WarshipPart != null;

    internal SeaMapField(SeaMap map, Position position)
    {
        this.map = map;
        this.position = position;
    }

    public override string ToString()
        => $"({position.X},{position.Y}):{(ContainsShip ? "ship" : "water" )}";

}
