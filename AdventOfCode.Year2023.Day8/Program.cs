using System.Collections.Immutable;
using System.Diagnostics;
using System.Text.RegularExpressions;

var nodeRegex = new Regex(@"(\w{3}) = \((\w{3}), (\w{3})\)");
var input = File.ReadAllLines("./input.txt");

var path = input[0].ToArray();
var nodes = input[2..]
   .Select(line =>
    {
        var groups = nodeRegex.Match(line).Groups;
        var key = groups[1].Value;
        var left = groups[2].Value;
        var right = groups[3].Value;
        return new Node(key, left, right);
    })
   .ToImmutableDictionary(node => node.Key);

var isEndOfPath = false;
var currentNodeKey = "AAA";
var currentActionIndex = 0;
var currentAction = path[currentActionIndex];
do
{
    nodes.TryGetValue(currentNodeKey, out var node);
    if (node is null) throw new Exception("Expected node did not exist");
    Console.WriteLine($"Current Node Location: '{node.Key}': {node.Left}, {node.Right}");

    currentNodeKey = currentAction switch
    {
        'L' => node.Left,
        'R' => node.Right,
        _ => throw new UnreachableException()
    };

    if (currentNodeKey == "ZZZ") isEndOfPath = true;
    else currentAction = path[(++currentActionIndex) % path.Length];
} while (!isEndOfPath);
Console.WriteLine($"Action Count: {currentActionIndex + 1}");


   
public record Node(string Key, string Left, string Right);