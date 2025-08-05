namespace SeaBattle.Application;

internal class Warship
{
    internal WarshipPart[] Parts { get; private set; }

    internal Warship(params Position[] partsRelativePositions)
    {
        Parts = partsRelativePositions
            .Select(relativePosition => new WarshipPart(this, relativePosition))
            .ToArray();
    }

    /// <summary>Otočí loď. Pozor, loď je nutné otočit před umístěním na hrací plochu</summary>
    internal void RotateWarship()
    {
        WarshipPart[] newParts = new WarshipPart[Parts.Length];

        for (int partIndex = 0; partIndex < Parts.Length; partIndex++)
        {
            newParts[partIndex] = new(this, new Position(Parts[partIndex].RelativePosition.Y, Parts[partIndex].RelativePosition.X));
        }

        Parts = newParts;
    }    

}
