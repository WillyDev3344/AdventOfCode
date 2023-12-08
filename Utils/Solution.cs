using System.Text.RegularExpressions;

namespace AdventOfCode.Utils
{
    abstract class Solution
    {
        const string UNSOLVED_MSG = "Not implemented yet !";

        public void Solve()
        {
            string pattern = @"\._(\d{4})\.(\w+)";

            Match match = Regex.Match(GetType().FullName, pattern);

            if (!match.Success ) throw new Exception("Could not match Day and Year from class namespace with Regex. " +
                "Check that the namespace of this class matches the pattern \"AdventOfCode._YEAR.DayX\"");

            string day = match.Groups[2].Value; 
            string year = match.Groups[1].Value;
            string path = $"F:\\Coding\\AdventOfCode\\{year}\\{day}\\input.txt";

            List<string> content = File.ReadLines(path).ToList();

            Console.WriteLine($"*** Solutions for {day} of {year} ***");

            string solveMsg;
            try
            {
                solveMsg = ExecutePart1(content);
            }
            catch (NotImplementedException)
            {
                solveMsg = UNSOLVED_MSG;
            }
            Console.WriteLine($"Part 1 answer : {solveMsg}");

            try
            {
                solveMsg = ExecutePart2(content);
            }
            catch (NotImplementedException)
            {
                solveMsg = UNSOLVED_MSG;
            }
            Console.WriteLine($"Part 2 answer : {solveMsg}");
        }

        protected abstract string ExecutePart1(List<string> inputContent);
        protected abstract string ExecutePart2(List<string> inputContent);
    }
}
