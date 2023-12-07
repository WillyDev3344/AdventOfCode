using AdventOfCode.Utils;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day5
{
    class Day5 : Solution
    {
        protected override string ExecutePart1(List<string> inputContent)
        {
            MatchCollection seedsNumberString = Regex.Matches(inputContent[0], @"\d+");
            List<long> seeds = new(); 
            foreach(Match match in seedsNumberString) seeds.Add(long.Parse(match.Value));


            List<List<long>> maps = new();
            int mapIndex = -1;
            for (int i = 1; i < inputContent.Count; i++)
            {
                string line = inputContent[i];
                MatchCollection matches = Regex.Matches(line, @"\d+");

                if (string.IsNullOrWhiteSpace(line)) continue;

                if (matches.Count <= 0)
                {
                    maps.Add([]);
                    mapIndex++;
                }
                else
                {
                    foreach(Match match in matches)
                    {
                        maps[mapIndex].Add(long.Parse(match.Value));
                    }
                }
            }


            for (int i = 0; i < seeds.Count; i++)
            {
                for (int j = 0; j < maps.Count; j++)
                {
                    for (int k = 0; k < maps[j].Count; k += 3)
                    {
                        if (seeds[i] >= maps[j][k + 1] && seeds[i] <= maps[j][k + 1]+ maps[j][k + 2]-1)
                        {
                            long x = seeds[i] - maps[j][k + 1];
                            seeds[i] = maps[j][k] + x;
                            break;
                        }
                    }
                }
            }


            return seeds.Min().ToString();
        }

        protected override string ExecutePart2(List<string> inputContent)
        {
            throw new NotImplementedException();
        }
    }
}
