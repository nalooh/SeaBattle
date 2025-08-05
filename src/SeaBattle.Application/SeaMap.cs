namespace SeaBattle.Application;

/// <summary>Hrací plocha</summary>
internal class SeaMap
{
    /// <summary>Pole na hrací ploše</summary>
    private readonly SeaMapField[,] fields;

    internal SeaMap(int mapSize)
    {
        fields = new SeaMapField[mapSize, mapSize];
        for (int x = 0; x < mapSize; x++)
        {
            for (int y = 0; y < mapSize; y++)
            {
                fields[x, y] = new(this, new Position(x, y));
            }
        }
    }

    /// <summary>Vrátí pole na hrací ploše</summary>
    /// <param name="position">Pozice pole</param>
    internal SeaMapField this[Position position]
        => IsValidPosition(position) ? fields[position.X, position.Y] : throw new Exception($"Pole {position.X}, {position.Y} se nenachází na hrací ploše");

    /// <summary>Ověří, jestli se daná pozice nachází na hrací ploše</summary>
    internal bool IsValidPosition(Position position)
        => position.X >= 0 && position.Y >= 0 && fields.GetLength(0) < position.X && fields.GetLength(1) < position.Y;

}
