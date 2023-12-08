using AdventOfCode.Utils;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day6
{
    class Day6 : Solution
    {
        protected override string ExecutePart1(List<string> inputContent)
        {
            MatchCollection timeMatches = Regex.Matches(inputContent[0], @"\d+");
            MatchCollection distanceMatches = Regex.Matches(inputContent[1], @"\d+");

            List<Tuple<int, int>> races = new();

            for (int i = 0; i < timeMatches.Count; i++)
            {
                races.Add(new(int.Parse(timeMatches[i].Value), int.Parse(distanceMatches[i].Value)));
            }

            int product = 1;

            for (int i = 0; i < races.Count; i++)
            {
                int time = races[i].Item1;
                int distanceNeeded = races[i].Item2;

                int j = 0;
                int k = time - 1;

                int firstWin = -1;
                int lastWin = -1;

                while(firstWin == -1 || lastWin == -1)
                {
                    if ((time - j) * j > distanceNeeded && firstWin == -1)
                    {
                        firstWin = j;
                    }

                    if ((time - k) * k > distanceNeeded && lastWin == -1){
                        lastWin = k;
                    }

                    j++;
                    k--;
                }

                int amount = lastWin - firstWin + 1;
                product *= amount;
            }

            return product.ToString();
        }

        protected override string ExecutePart2(List<string> inputContent)
        {
            throw new NotImplementedException();
        }
    }
}
