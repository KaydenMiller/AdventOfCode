using System.Text.RegularExpressions;

var fileInput = File.ReadAllLines("./input.txt");
var numericTextRegexLeftToRight = new Regex("(one|two|three|four|five|six|seven|eight|nine|[1-9])");
var numericTextRegexRightToLeft = new Regex("(one|two|three|four|five|six|seven|eight|nine|[1-9])", RegexOptions.RightToLeft);
var calibrationSum = fileInput
   .Select(line =>
      numericTextRegexLeftToRight.Matches(line).Concat(numericTextRegexRightToLeft.Matches(line)).ToArray()
   )
   .Select(matchGroup => (matchGroup.First(), matchGroup.Last()))
   .Select((valueGroup, index) =>
   {
      var firstNumber = valueGroup.Item1.Length == 1 && char.IsNumber(valueGroup.Item1.Value[0]) ? int.Parse(valueGroup.Item1.Value) : FromNumericString(valueGroup.Item1.Value);
      var secondNumber = valueGroup.Item2.Length == 1 && char.IsNumber(valueGroup.Item2.Value[0]) ? int.Parse(valueGroup.Item2.Value) : FromNumericString(valueGroup.Item2.Value);
      return int.Parse($"{firstNumber}{secondNumber}");
   })
  .Sum();
Console.WriteLine($"Calibration Value: {calibrationSum}");
return;

int FromNumericString(string numberName)
{
   return numberName switch
   {
      "one" => 1,
      "two" => 2,
      "three" => 3,
      "four" => 4,
      "five" => 5,
      "six" => 6,
      "seven" => 7,
      "eight" => 8,
      "nine" => 9
   };
}