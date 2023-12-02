using AdventOfCode.Utils;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day2
{
    class Day2 : Solution
    {
        protected override string ExecutePart1(List<string> inputContent)
        {
            string pullsPattern = @"(\d+)\s+(\w+)";
            string gameIdPattern = @"^[^\d]*(\d+)";
            int sum = 0;
            
            foreach (string line in inputContent)
            {
                MatchCollection pulls = Regex.Matches(line, pullsPattern);
                bool validGame = true;
                for (int i = 0; i < pulls.Count && validGame; i++)
                {
                    int cubeAmount = int.Parse(pulls[i].Groups[1].Value);
                    string color = pulls[i].Groups[2].Value;

                    if (cubeAmount > 14 ||
                        cubeAmount == 14 && !color.Equals("blue") ||
                        cubeAmount == 13 && color.Equals("red"))
                    {
                        validGame = false;
                    }
                }
                if (validGame)
                {
                    int gameID = int.Parse(Regex.Match(line, gameIdPattern).Groups[1].Value);
                    sum += gameID;
                }
            }
            return sum.ToString();
        }

        protected override string ExecutePart2(List<string> inputContent)
        {
            string pullsPattern = @"(\d+)\s+(\w+)";
            int sum = 0;

            foreach (string line in inputContent)
            {
                MatchCollection pulls = Regex.Matches(line, pullsPattern);
                int power = 0, biggestRed = 0, biggestGreen = 0, biggestBlue = 0;

                for (int i = 0; i < pulls.Count; i++)
                {
                    int cubeAmount = int.Parse(pulls[i].Groups[1].Value);
                    string color = pulls[i].Groups[2].Value;

                    switch (color)
                    {
                        case "red":
                            if (cubeAmount > biggestRed) biggestRed = cubeAmount; 
                            break;
                        case "green":
                            if (cubeAmount > biggestGreen) biggestGreen = cubeAmount;
                            break;
                        case "blue":
                            if(cubeAmount > biggestBlue) biggestBlue = cubeAmount;
                            break;
                        default: break;
                    }
                }
                power = biggestRed * biggestGreen * biggestBlue;
                sum += power;
            }
            return sum.ToString();
        }
    }
}
