using System.Globalization;

var inputLines = File.ReadLines("./input.txt");
var elves = new List<Elf>();
var items = new List<int>();
var currentElfIndex = 0;
foreach (var inputLine in inputLines)
{
    var success = int.TryParse(inputLine, out var itemCalories);

    if (success)
    {
        items.Add(itemCalories);
    }
    else
    {
        elves.Add(new Elf(currentElfIndex, items.ToList()));
        items.Clear();
        currentElfIndex++;
    }
}

var orderedElves = elves.OrderByDescending(elf => elf.FoodItems.Sum()).ToArray();

foreach (var elf in orderedElves)
{
    Console.WriteLine($"Elf: {elf.id}, total calories: {elf.FoodItems.Sum()}, items: {elf.FoodItems.Count}");
}

Console.WriteLine($"Elf with most calories: {orderedElves.First().id} with {orderedElves.First().FoodItems.Sum()}");

// Part 2 top 3 elfs with most calories total calories
var top3TotalCalories = orderedElves.Take(3).Sum(x => x.FoodItems.Sum());
Console.WriteLine($"Top 3 Elves total calories: {top3TotalCalories}");