using AdventOfCode.Day4;
using FluentAssertions;

namespace AdventOfCode.Tests;

public class Day4
{
    [Theory]
    [InlineData("2-4,6-8")]
    [InlineData("2-3,4-5")]
    [InlineData("5-7,7-9")]
    public void DoNotContainAll(string pair)
    {
        var elves = Elf.FromSectionPairString(pair);
        var doesContain = elves.Item1.EitherContains(elves.Item2);
        doesContain.Should().BeFalse();
    }
    
    [Theory]
    [InlineData("2-8,3-7")]
    public void DoesContainAll(string pair)
    {
        var elves = Elf.FromSectionPairString(pair);
        var doesContain = elves.Item1.EitherContains(elves.Item2);
        doesContain.Should().BeTrue();
    }
    
    [Theory]
    [InlineData("2-4,6-8")] 
    [InlineData("2-3,4-5")] 
    public void DoNotHaveOverlap(string pair)
    {
        var elves = Elf.FromSectionPairString(pair);
        var hasOverlap = elves.Item1.HasOverlappingSections(elves.Item2);
        hasOverlap.Should().BeFalse();
    }

    [Theory]
    [InlineData("5-7,7-9")]
    [InlineData("1-2,2-3")] 
    public void HasSomeOverlap(string pair)
    {
        var elves = Elf.FromSectionPairString(pair);
        var hasOverlap = elves.Item1.HasOverlappingSections(elves.Item2);
        hasOverlap.Should().BeTrue(); 
    }
}