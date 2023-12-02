using System.Text.RegularExpressions;

namespace AdventOfCode.Utils
{
    abstract class Solution
    {
        public void Solve()
        {
            string pattern = @"\._(\d{4})\.(\w+)";
            Regex regex = new(pattern);

            Match match = regex.Match(GetType().FullName);

            if (!match.Success ) throw new Exception("Could not match Day and Year from class namespace with Regex. " +
                "Check that the namespace of this class matches the pattern \"AdventOfCode._YEAR.DayX\"");

            string day = match.Groups[2].Value; 
            string year = match.Groups[1].Value;
            string path = $"F:\\Coding\\AdventOfCode\\{year}\\{day}\\input.txt";

            List<string> content = File.ReadLines(path).ToList();

            string part1 = ExecutePart1(content);
            Console.WriteLine($"Part 1 answer : {part1}");
            
            string part2 = ExecutePart2(content);
            Console.WriteLine($"Part 2 answer : {part2}");

        }

        protected abstract string ExecutePart1(List<string> inputContent);
        protected abstract string ExecutePart2(List<string> inputContent);
    }
}
