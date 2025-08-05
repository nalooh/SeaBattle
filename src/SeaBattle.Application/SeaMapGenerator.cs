namespace SeaBattle.Application;

/// <summary>Třída pro vytvoření hrací plochy</summary>
internal static class SeaMapGenerator
{
    /// <summary>Vytvoří novou mapu s náhodně umístěnými loďmi</summary>
    /// <param name="mapSize">Velikost hrací plochy</param>
    public static SeaMap Generate(int mapSize)
    {
        SeaMap newMap = new(mapSize);

        Random rnd = new();

        // Zatím se seznam lodí generuje napevno v kódu, bude potřeba upravit
        Warship[] warships = [
            new Warship(new Position(0, 1), new Position(1, 0), new Position(1, 1), new Position(1, 2), new Position(1, 3), new Position(2, 1)),
            new Warship(new Position(0, 1), new Position(1, 0), new Position(1, 1), new Position(1, 2), new Position(2, 1)),
            new Warship(new Position(0, 0), new Position(0, 1), new Position(0, 2)),
            new Warship(new Position(0, 0), new Position(0, 1)),
            new Warship(new Position(0, 0), new Position(0, 1)),
            new Warship(new Position(0, 0)),
            new Warship(new Position(0, 0)),
        ];

        foreach (Warship warship in warships)
        {
            // Náhodná rotace
            if (rnd.Next(2) == 1)
            {
                warship.RotateWarship();
            }

            // Náhodné umístění
            Position[] validPositions = GetValidPositionsForWarship(newMap, warship);
            if (validPositions.Length == 0)
            {
                throw new Exception("Nepodařilo se umístit všechny lodě na hrací plochu.");
            }
            int selectedPosition = rnd.Next(validPositions.Length);
            newMap.AddWarship(warship, validPositions[selectedPosition]);
        }

        return newMap;
    }

    /// <summary>Vrátí seznam možných umístění pro danou loď</summary>
    /// <param name="warship">Umisťovaná loď</param>
    private static Position[] GetValidPositionsForWarship(SeaMap map, Warship warship)
    {
        List<Position> validPositions = [];
        for (int x = 0; x < map.Width; x++)
        {
            for (int y = 0; y < map.Height; y++)
            {
                Position position = new(x, y);
                if (map.IsValidPositionForWarship(warship, position))
                {
                    validPositions.Add(position);
                }
            }
        }
        return validPositions.ToArray();
    }

}
