const int LOWER_CASE_PRIORITY = -64 - 32;
const int UPPER_CASE_PRIORITY = -64 + 26;

var file = File.ReadAllLines("./input.txt");

var sackPriorities = file
   .Select((l, index) => new { index, line = l })
   .GroupBy(g => g.index / 3, i => i.line)
   .Select(GetGroupedCharacter)
   .Select(GetCharacterPriority)
   .Sum();

Console.WriteLine(sackPriorities);

return;

char GetGroupedCharacter(IGrouping<int, string> characterGrouping)
{
    var dict = new Dictionary<char, int>();
    var canUpdate = new Dictionary<char, bool>();
    foreach (var row in characterGrouping)
    {
        canUpdate.Clear();
        foreach (var character in row)
        {
            if (!canUpdate.ContainsKey(character))
            {
                if (dict.TryAdd(character, 1) is false)
                {
                    dict[character]++;
                }
                canUpdate.TryAdd(character, false);
            }
        }
    }
    var badgeCharacter = dict.Single(c => c.Value == 3).Key;
    return badgeCharacter; 
}

int GetCharacterPriority(char character)
{
    if (char.IsLower(character))
        return character + LOWER_CASE_PRIORITY;
    return character + UPPER_CASE_PRIORITY;
}

char GetErrorCharacter(string line)
{
    var halfLength = line.Length / 2;
    var firstHalf = line.Substring(0, halfLength);
    var lastHalf = line.Substring(halfLength, line.Length - halfLength);
    var dict = new Dictionary<char, int>();
    foreach (var c in firstHalf)
    {
        dict.TryAdd(c, 1);
    }
    foreach (var c in lastHalf.Where(c => dict.ContainsKey(c)))
    {
        dict[c]++;
    }
    var errorChar = dict.Single(c => c.Value >= 2).Key;
    return errorChar;
}