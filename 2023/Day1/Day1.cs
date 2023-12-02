using AdventOfCode.Utils;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day1
{
    class Day1 : Solution
    {
        protected override string ExecutePart1(List<string> inputContent)
        {
            int sum = 0;
            foreach (string line in inputContent)
            {
                string allNumbers = Regex.Replace(line, @"[^\d]", "");
                char[] number = [allNumbers[0], allNumbers[^1]];
                int num = int.Parse(new string(number));

                sum += num;
            }
            
            return sum.ToString();
        }

        protected override string ExecutePart2(List<string> inputContent)
        {
            Dictionary<string, int> numberConversionDict = new()
            {
                { "one", 1},
                {"two", 2 },
                {"three", 3 },
                {"four", 4 },
                {"five", 5 },
                {"six", 6 },
                {"seven", 7 },
                {"eight", 8 },
                {"nine", 9 }
            };

            string pattern = @"(?=(" + string.Join("|", numberConversionDict.Keys.Select(Regex.Escape)) + @"|\d+))";

            int sum = 0;

            foreach (string line in inputContent)
            {
                MatchCollection matches = Regex.Matches(line, pattern);

                string firstMatch = matches.First().Groups[1].Value;
                string lastMatch = matches.Last().Groups[1].Value;

                int firstNum = 10;
                int lastNum = 1;

                if (!char.IsDigit(firstMatch[0])) firstNum *= numberConversionDict[firstMatch];
                else firstNum *= (int)char.GetNumericValue(firstMatch[0]);

                if (!char.IsDigit(lastMatch[0])) lastNum *= numberConversionDict[lastMatch];
                else lastNum *= (int)char.GetNumericValue(lastMatch[0]);

                sum += (firstNum + lastNum);
            }

            return sum.ToString();
        }
    }
}