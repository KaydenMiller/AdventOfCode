using AdventOfCode.Year2023.Day2;

var input = File.ReadAllLines("./input.txt");

var gamesPart1 = input
   .Select(element => CubeGame.CreateFromGameString(element))
   .Where(game => !game.HasError)
   .Sum(game => game.GameId);

Console.WriteLine($"PART1: Game Ids With Errors Sum {gamesPart1}");

var gamesPart2 = input
   .Select(element => CubeGame.CreateFromGameString(element, int.MaxValue, int.MaxValue, int.MaxValue))
   .Select(game =>
    {
        var sets = game.Sets.ToArray();
        var maxRed = sets.Max(x => x.RedCubes);
        var maxGreen = sets.Max(x => x.GreenCubes);
        var maxBlue = sets.Max(x => x.BlueCubes);
        return maxRed * maxGreen * maxBlue;
    })
   .Sum();
Console.WriteLine($"PART2: Sum of powers of max cubes: {gamesPart2}");