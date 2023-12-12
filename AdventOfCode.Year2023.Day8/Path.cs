using System.Collections.Immutable;
using System.Diagnostics;

namespace AdventOfCode.Year2023.Day8;

public class Path
{
    public ImmutableArray<Direction> Directions { get; }
    
    public Path(IEnumerable<Direction> directions)
    {
        Directions = directions.ToImmutableArray();
    }

    public static Path ParseFromPathString(string path)
    {
        var parsedPath = path.Select(character =>
        {
            return character switch
            {
                'L' => Direction.Left,
                'R' => Direction.Right,
                _ => throw new UnreachableException()
            };
        });

        return new Path(parsedPath);
    }

    public Direction GetDirectionAfterSteps(int steps)
    {
        return Directions[steps % Directions.Length];
    }

    public enum Direction
    {
        Left,
        Right
    }
}