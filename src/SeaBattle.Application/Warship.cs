namespace SeaBattle.Application;

internal class Warship
{
    internal WarshipPart[] Parts { get; }

    internal Warship(params Position[] partsRelativePositions)
    {
        Parts = partsRelativePositions
            .Select(relativePosition => new WarshipPart(this, relativePosition))
            .ToArray();
    }

}
