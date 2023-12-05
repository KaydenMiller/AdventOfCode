using AdventOfCode.Day4;

var lines = File.ReadAllLines("./input.txt");

var elfPairsContainingOtherElf = lines
   .Select(Elf.FromSectionPairString)
   .Select(elves => elves.Item1.EitherContains(elves.Item2))
   .Count(e => e is true);
Console.WriteLine(elfPairsContainingOtherElf);

var elfPairsOverlapping = lines
   .Select(Elf.FromSectionPairString)
   .Select(elves => elves.Item1.HasOverlappingSections(elves.Item2))
   .Count(e => e is true);
Console.WriteLine(elfPairsOverlapping);

