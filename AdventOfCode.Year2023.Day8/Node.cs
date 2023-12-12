using System.Text.RegularExpressions;

namespace AdventOfCode.Year2023.Day8;

public class Node
{
    public string Key { get; }
    public string Left { get; }
    public string Right { get; }

    public Node(string key, string left, string right)
    {
        Key = key;
        Left = left;
        Right = right;
    }

    public static Node ParseFromNodeString(string node)
    {
        var nodeRegex = new Regex(@"(\w{3}) = \((\w{3}), (\w{3})\)");
        var groups = nodeRegex.Match(node).Groups;
        var key = groups[1].Value;
        var left = groups[2].Value;
        var right = groups[3].Value;
        return new Node(key, left, right);
    }
}

public static class NodeExtensions
{
    public static Node GetNode(this IDictionary<string, Node> nodes, string key)
    {
        nodes.TryGetValue(key, out var node);
        if (node is null) throw new Exception("Expected node did not exist");
        return node;
    }
    public static Node GetNextNode(this IDictionary<string, Node> nodes, Node startNode)
    {
        var node = nodes.GetNode()
    }
}