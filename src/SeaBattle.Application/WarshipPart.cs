namespace SeaBattle.Application;

/// <summary>Část lodi odpovídající jednomu poli na hrací ploše</summary>
internal class WarshipPart
{
    /// <summary>Loď, ke které část patří</summary>
    internal Warship Warship { get; }

    /// <summary>Pozice relativní k pozici začátku lodě</summary>
    internal Position RelativePosition { get; }

    /// <summary>Pole, na které je část lodi umístěna</summary>
    internal SeaMapField? Field { get; set; } = null;

    /// <summary>Informace o tom, jestli byla část lodi zasažena</summary>
    internal bool IsHit { get; set; } = false;

    /// <summary>Vytvoří novou část lodi</summary>
    /// <param name="warship">Loď, ke které část patří</param>
    /// <param name="relativePosition">Pozice relativně k lodi</param>
    internal WarshipPart(Warship warship, Position relativePosition)
    {
        Warship = warship;
        RelativePosition = relativePosition;
    }

}
