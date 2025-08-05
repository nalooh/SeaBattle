namespace SeaBattle.Application;

internal class Warship
{
    /// <summary>Jednotlivá pole lodě</summary>
    internal WarshipPart[] Parts { get; private set; }

    internal Warship(params Position[] partsRelativePositions)
    {
        Parts = partsRelativePositions
            .Select(relativePosition => new WarshipPart(this, relativePosition))
            .ToArray();
    }

    /// <summary>Otočí loď před umístěním na hrací plochu</summary>
    internal void RotateWarship()
    {
        if (Parts.Any(part => part.Field != null))
        {
            throw new Exception("Loď není možné otočit, pokud je již umístěna na hrací ploše");
        }
        WarshipPart[] newParts = new WarshipPart[Parts.Length];

        for (int partIndex = 0; partIndex < Parts.Length; partIndex++)
        {
            newParts[partIndex] = new(this, new Position(Parts[partIndex].RelativePosition.Y, Parts[partIndex].RelativePosition.X));
        }

        Parts = newParts;
    }    

}
