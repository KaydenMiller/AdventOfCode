var input = File.ReadAllLines("./input.txt");
// var mergedInput = string.Join("", input);
//
// List<Element> elements = new List<Element>();
// foreach (var character in mergedInput.Select((value, index) => new { value, index }))
// {
//     int? startPos = null;
//     var chars = new List<char>();
//     if (char.IsNumber(character.value))
//     {
//         startPos = character.index;
//         chars.Add(character.value);
//     }
//     else if (startPos is not null)
//     {
//         var endPos = character.index;
//         chars.Add(character.value);
//         elements.Add(new Element(startPos, endPos, chars));
//     }
// }
//
// // 1 2 3
// // 4 5 6
// // 7 8 9
//
// // n-4 n-3 n-2
// // n-1 n n+1
// // n+2 n+3 n+4
//
// // 123456789
//
// public record Element(int StartIndex, int EndIndex, IEnumerable<char> Values);