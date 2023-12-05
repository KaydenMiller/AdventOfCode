using System.Text.RegularExpressions;

namespace AdventOfCode.Day4;

public struct Elf
{
    public int Min { get; private set; }
    public int Max { get; private set; }

    public Elf(int min, int max)
    {
        Min = min;
        Max = max;
    }

    public bool ContainsAllSections(Elf elfOther)
    {
        return Min <= elfOther.Min && Max >= elfOther.Max;
    }

    public bool HasOverlappingSections(Elf elfOther)
    {
        var result = Min <= elfOther.Max && Max >= elfOther.Min;
        return result;
    }

    public static Elf FromSectionRangeString(string range)
    {
        var elfSectionRegex = new Regex("(\\d+)-(\\d+)");
        var elfMatch = elfSectionRegex.Match(range);
        var elf = new Elf(int.Parse(elfMatch.Groups[1].Value), int.Parse(elfMatch.Groups[2].Value));
        return elf;
    }

    public static (Elf, Elf) FromSectionPairString(string pair)
    {
        var elfPairRegex = new Regex("(.*?),(.*)");
        var elfPairMatch = elfPairRegex.Match(pair);

        var elf1 = Elf.FromSectionRangeString(elfPairMatch.Groups[1].Value);
        var elf2 = Elf.FromSectionRangeString(elfPairMatch.Groups[2].Value);

        return (elf1, elf2); 
    }
}

public static class ElfExtensions
{
    public static bool EitherContains(this Elf elf1, Elf elf2)
    {
        return elf1.ContainsAllSections(elf2) || elf2.ContainsAllSections(elf1);
    }
}