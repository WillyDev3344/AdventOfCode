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
            throw new NotImplementedException();
        }
    }
}