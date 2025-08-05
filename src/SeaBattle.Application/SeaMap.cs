namespace SeaBattle.Application;

/// <summary>Hrací plocha</summary>
internal class SeaMap
{
    /// <summary>Pole na hrací ploše</summary>
    private readonly SeaMapField[,] fields;

    /// <summary>Seznam lodí umístěných na hrací ploše</summary>
    private readonly List<Warship> warships = [];

    /// <summary>Šířka hrací plochy</summary>
    internal int Width
        => fields.GetLength(0);

    /// <summary>Výška hrací plochy</summary>
    internal int Height
        => fields.GetLength(1);

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
        => position.X >= 0 && position.Y >= 0 && position.X < Width && position.Y < Height;

    /// <summary>Vrátí pole na hrací ploše, pokud existuje</summary>
    /// <param name="position">Pozice na hrací ploše</param>
    /// <param name="seaMapField">Pole hrací plochy</param>
    /// <returns>Pokud pole existuje tak true jinak false</returns>
    internal bool TryGetPosition(Position position, [System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out SeaMapField seaMapField)
    {
        if (IsValidPosition(position))
        {
            seaMapField = this[position];
            return true;
        }
        else
        {
            seaMapField = null;
            return false;
        }
    }

    /// <summary>Pokud je to možné, přídá loď na hrací plochu</summary>
    /// <param name="warship">Umisťovaná loď</param>
    /// <param name="position">Pozice pro umístění lodi</param>
    internal void AddWarship(Warship warship, Position position)
    {
        if (IsValidPositionForWarship(warship, position))
        {
            foreach (WarshipPart part in warship.Parts)
            {
                Position partPosition = position + part.RelativePosition;
                this[partPosition].WarshipPart = part;
                part.Field = this[partPosition];
            }
            warships.Add(warship);
        }
    }

    /// <summary>Ověří, jestli je možné danou loď umístit na pozici na hrací ploše</summary>
    /// <param name="warship">Umisťovaná loď</param>
    /// <param name="position">Pozice umisťované lodi</param>
    /// <returns></returns>
    internal bool IsValidPositionForWarship(Warship warship, Position position)
    {
        foreach (WarshipPart warshipPart in warship.Parts)
        {
            Position partPosition = position + warshipPart.RelativePosition;
            if (!IsValidPosition(partPosition))
            {
                return false;
            }
            foreach (SeaMapField field in GetCloseFields(partPosition))
            {
                if (field.ContainsShip)
                {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary>Vrátí všechna platná pole v blízkosti</summary>
    /// <param name="position">Pozice, pro kterou se hledají pole v blízkosti</param>
    private List<SeaMapField> GetCloseFields(Position position)
    {
        List<SeaMapField> closeFields = [];
        if (TryGetPosition(position + new Position(-1, -1), out SeaMapField? mapFieldMM)) closeFields.Add(mapFieldMM);
        if (TryGetPosition(position + new Position(-1, 0), out SeaMapField? mapFieldMZ)) closeFields.Add(mapFieldMZ);
        if (TryGetPosition(position + new Position(-1, 1), out SeaMapField? mapFieldMP)) closeFields.Add(mapFieldMP);
        if (TryGetPosition(position + new Position(0, -1), out SeaMapField? mapFieldZM)) closeFields.Add(mapFieldZM);
        if (TryGetPosition(position + new Position(0, 0), out SeaMapField? mapFieldZZ)) closeFields.Add(mapFieldZZ);
        if (TryGetPosition(position + new Position(0, 1), out SeaMapField? mapFieldZP)) closeFields.Add(mapFieldZP);
        if (TryGetPosition(position + new Position(1, -1), out SeaMapField? mapFieldPM)) closeFields.Add(mapFieldPM);
        if (TryGetPosition(position + new Position(1, 0), out SeaMapField? mapFieldPZ)) closeFields.Add(mapFieldPZ);
        if (TryGetPosition(position + new Position(1, 1), out SeaMapField? mapFieldPP)) closeFields.Add(mapFieldPP);
        return closeFields;
    }

}
