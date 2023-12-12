using System.Collections.Immutable;
using System.Diagnostics;
using AdventOfCode.Year2023.Day8;

var input = File.ReadAllLines("./input.txt");

var path = AdventOfCode.Year2023.Day8.Path.ParseFromPathString(input[0]);
var nodes = input[2..]
   .Select(Node.ParseFromNodeString)
   .ToImmutableDictionary(node => node.Key);

var isEndOfPath = false;
var currentNodeKey = "AAA";
var currentActionIndex = 0;
var currentAction = path[currentActionIndex];
do
{
    var node = nodes.GetNode(currentNodeKey);
    Console.WriteLine($"Current Node Location: '{node.Key}': {node.Left}, {node.Right}");
    
    nodes.GetNextNode()
    currentNodeKey = path.GetDirectionAfterSteps(currentActionIndex);

    if (currentNodeKey == "ZZZ") isEndOfPath = true;
    else currentAction = path[(++currentActionIndex) % path.Length];
} while (!isEndOfPath);
Console.WriteLine($"Action Count: {currentActionIndex + 1}");
