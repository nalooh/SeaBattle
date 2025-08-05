namespace SeaBattle.Application;

/// <summary>Pole na hrací ploše</summary>
internal class SeaMapField
{
    /// <summary>Odkaz na hrací plochu, na které se pole nachází</summary>
    private readonly SeaMap map;

    /// <summary>Pozice pole na hrací ploše</summary>
    private readonly Position position;

    internal SeaMapField(SeaMap map, Position position)
    {
        this.map = map;
        this.position = position;
    }

}
