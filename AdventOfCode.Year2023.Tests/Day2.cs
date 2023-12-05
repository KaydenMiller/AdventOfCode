using AdventOfCode.Year2023.Day2;
using FluentAssertions;

namespace AdventOfCode.Year2023.Tests;

public class Day2
{
    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", false)]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", false)]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", true)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", true)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", false)]
    public void Part1(string input, bool expectedGameIsError)
    {
        var game = CubeGame.CreateFromGameString(input, 12, 13, 14);
        game.HasError.Should().Be(expectedGameIsError);
    }
    
    [Theory]
    [InlineData(new[]
    {
        "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
        "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
        "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
        "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
        "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
    }, 8)]
    public void Part1Sum(string[] input, int expectedSum)
    {
        var gamesPart1 = input
           .Select(element => CubeGame.CreateFromGameString(element))
           .Where(game => !game.HasError)
           .Sum(game => game.GameId);
        gamesPart1.Should().Be(expectedSum);
    }
    
    [Theory] 
    [InlineData("Game 1: 1 blue, 2 green, 3 red; 7 red, 8 green; 1 green, 2 red, 1 blue; 2 green, 3 red, 1 blue; 8 green, 1 blue", 7, 8, 1)]
    [InlineData("Game 2: 12 blue, 3 green, 5 red; 1 green, 1 blue, 8 red; 2 green, 12 blue, 5 red; 7 red, 2 green, 13 blue", 8, 3, 13)]
    [InlineData("Game 3: 7 red, 4 blue, 13 green; 14 green, 1 blue, 1 red; 1 red, 11 green, 5 blue; 10 green, 3 blue, 3 red; 5 red, 5 blue, 3 green", 7, 14, 5)]
    public void Part2(string input, int expectedRed, int expectedGreen, int expectedBlue)
    {
        var game = CubeGame.CreateFromGameString(input, int.MaxValue, int.MaxValue, int.MaxValue);
        var sets = game.Sets.ToArray();
        var maxRed = sets.Max(x => x.RedCubes);
        var maxGreen = sets.Max(x => x.GreenCubes);
        var maxBlue = sets.Max(x => x.BlueCubes);
        var result = maxRed * maxGreen * maxBlue;
        result.Should().Be(expectedRed * expectedGreen * expectedBlue);
    }
}