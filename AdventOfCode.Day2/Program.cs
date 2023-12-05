using AdventOfCode.Day2;

var inputs = File.ReadLines("./input.txt");

var engine = new RockPaperScissorsEngine();

foreach (var round in inputs)
{
    var choices = round.Split(" ");
    engine.Play(choices[0][0], choices[1][0]);
}

Console.WriteLine($"Score: {engine.Score}");