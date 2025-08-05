namespace SeaBattle.Application;

/// <summary>Pozice na hrací ploše</summary>
public record struct Position(int X, int Y)
{
    public static Position operator +(Position positionA, Position positionB)
    {
        return new(positionA.X + positionB.X, positionA.Y + positionB.Y);
    }

    public static Position operator -(Position positionA, Position positionB)
    {
        return new(positionA.X - positionB.X, positionA.Y - positionB.Y);
    }
    
}
