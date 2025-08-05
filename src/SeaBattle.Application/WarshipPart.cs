namespace SeaBattle.Application;

internal class WarshipPart
{
    internal Warship Warship { get; }

    internal Position RelativePosition { get; }

    internal WarshipPart(Warship warship, Position relativePosition)
    {
        Warship = warship;
        RelativePosition = relativePosition;
    }

}
