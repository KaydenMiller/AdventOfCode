using System.Collections.Immutable;
using System.Text.RegularExpressions;
using ErrorOr;

namespace AdventOfCode.Year2023.Day2;

public class CubeGame
{
    private const int MAX_RED = 12;
    private const int MAX_GREEN = 13;
    private const int MAX_BLUE = 14;
    
    public enum CubeColor
    {
        Red,
        Green,
        Blue
    }

    private static readonly Regex GameStringRegex = new(@"Game (\d+):(.*)");
    private static readonly Regex SetParseRegex = new(@"(\d+)\s(\w+)");


    public int GameId { get; private set; }
    public IEnumerable<EntrySet> Sets { get; private set; }
    public bool HasError { get; private set; }

    private CubeGame(int gameId, IEnumerable<EntrySet> sets, bool hasError = false)
    {
        GameId = gameId;
        Sets = sets;
        HasError = hasError;
    }

    public static CubeGame CreateFromGameString(string game, int redMax = MAX_RED, int greenMax = MAX_GREEN, int blueMax = MAX_BLUE)
    {
        var match = GameStringRegex.Match(game);
        var gameId = int.Parse(match.Groups[1].Value);
        var gameSets = match.Groups[2].Value.Split(';').Select(s => s.Trim());
        var parsedSets = gameSets
           .Select(set => SetParseRegex.Matches(set))
           .Select(matchCol =>
            {
                var set = matchCol
                   .Select(innerMatch =>
                    {
                        var count = int.Parse(innerMatch.Groups[1].Value);
                        var type = innerMatch.Groups[2].Value;
                        var parsedType = type switch
                        {
                            "red" => CubeColor.Red,
                            "green" => CubeColor.Green,
                            "blue" => CubeColor.Blue,
                            _ => throw new ArgumentOutOfRangeException()
                        };

                        return new Cube(count, parsedType);
                    }).ToImmutableArray();

                var red = set.SingleOrDefault(x => x.Color == CubeColor.Red).Count;
                var green = set.SingleOrDefault(x => x.Color == CubeColor.Green).Count;
                var blue = set.SingleOrDefault(x => x.Color == CubeColor.Blue).Count;

                return EntrySet.Create(red, green, blue, redMax, greenMax, blueMax);
            }).ToImmutableArray();

        var hasError = parsedSets.Any(set => set.IsError);
        return new CubeGame(gameId, parsedSets.Select(set => set.Value), hasError);
    }

    public struct EntrySet
    {
        public int RedCubes { get; }
        public int GreenCubes { get; }
        public int BlueCubes { get; }

        public static ErrorOr<EntrySet> Create(int redCubes, int greenCubes, int blueCubes, int redMax, int greenMax, int blueMax)
        {
            if (redCubes > redMax)
                return Error.Validation("red");
            if (greenCubes > greenMax)
                return Error.Validation("green");
            if (blueCubes > blueMax)
                return Error.Validation("blue");
            
            return new EntrySet(redCubes, greenCubes, blueCubes);
        }

        public EntrySet(int redCubes, int greenCubes, int blueCubes)
        {
            RedCubes = redCubes;
            GreenCubes = greenCubes;
            BlueCubes = blueCubes;
        }
    }


    public struct Cube
    {
        public int Count { get; }
        public CubeColor Color { get; }

        public Cube(int count, CubeColor color)
        {
            Count = count;
            Color = color;
        }
    }
}