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

            List<List<long>> maps = GetMaps(inputContent);

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
            //MatchCollection seedsNumberString = Regex.Matches(inputContent[0], @"\d+");
            //List<Tuple<long, long>> seedRanges = new();

            //for (int i = 0; i < seedsNumberString.Count; i+=2)
            //{
            //    seedRanges.Add(new Tuple<long, long>(long.Parse(seedsNumberString[i].Value), long.Parse(seedsNumberString[i + 1].Value)));
            //}

            //List<List<long>>  maps = GetMaps(inputContent);


            //for (int j = 0; j < maps.Count; j++)
            //{
            //    for (int i = 0; i < seedRanges.Count; i++)
            //    {
            //        for (int k = 0; k < maps[i].Count; k += 3)
            //        {
            //            // If seed range is not matched
            //            if(seedRanges[i].Item1 > maps[i][k+1] + maps[i][k + 2] - 1 ||
            //               seedRanges[i].Item1 + seedRanges[i].Item2 - 1 < maps[i][k + 1])
            //            {
            //                continue;
            //            }
            //            // If seed range is fully matched
            //            else if (seedRanges[i].Item1 >= maps[i][k + 1] && 
            //                seedRanges[i].Item1 + seedRanges[i].Item2 -1  <= maps[i][k + 1] + maps[i][k + 2] - 1)
            //            {
            //                long x = seedRanges[i].Item1 - maps[i][k + 1];
            //                seedRanges[i] = new(seedRanges[i].Item1 + x, seedRanges[i].Item2 + x);
            //                break;
            //            }
            //            // If seed range is partially matched
            //            else
            //            {
            //                // Case 1 : Seed range starts  and ends out of map range
            //                if (seedRanges[i].Item1 < maps[i][k + 1] &&
            //                    seedRanges[i].Item1 + seedRanges[i].Item2 - 1 > maps[i][k + 1] + maps[i][k + 2] - 1)
            //                {
            //                    Tuple<long, long> unmatchedStartRange = new(seedRanges[i].Item1, maps[i][k + 1] - seedRanges[i].Item1);
            //                    Tuple<long, long> unmatchedEndRange = new(maps[j][k+1] + maps[j][k+2],
            //                        (seedRanges[i].Item1 + seedRanges[i].Item2) - (maps[j][k + 1] + maps[j][k + 2]));

            //                    seedRanges[i] = new(maps[j][k], maps[j][k+2]);
            //                    seedRanges.Insert(i+1, unmatchedStartRange);
            //                    seedRanges.Insert(i + 1, unmatchedEndRange);
            //                }
            //                // Case 2 : Seed range starts out of map range, but ends in it
            //                else if (seedRanges[i].Item1 < maps[i][k + 1])
            //                {
            //                    Tuple<long, long> unmatchedStartRange = new(seedRanges[i].Item1, maps[i][k + 1] - seedRanges[i].Item1);
            //                    seedRanges[i] = new(maps[j][k], (seedRanges[i].Item1 + seedRanges[i].Item2) - maps[j][k+1]);
            //                    seedRanges.Insert(i+1, unmatchedStartRange);
            //                }
            //                // Case 3 : Seed range starts in map range, but ends out of it
            //                else
            //                {
            //                    Tuple<long, long> unmatchedEndRange = new(maps[j][k + 1] + maps[j][k + 2],
            //                        (seedRanges[i].Item1 + seedRanges[i].Item2) - (maps[j][k + 1] + maps[j][k + 2]));

            //                    long captureLenght = seedRanges[i].Item2 - unmatchedEndRange.Item2;

            //                    seedRanges[i] = new(maps[j][k] + captureLenght - 1, captureLenght);

            //                    seedRanges.Insert(i + 1, unmatchedEndRange);
            //                }
            //            }
            //        }
            //    }
            //}

            //return seedRanges.Min(seedRange => seedRange.Item1).ToString();
            return "Not solved yet !";
        }

        private List<List<long>> GetMaps(List<string> inputContent)
        {
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
                    foreach (Match match in matches)
                    {
                        maps[mapIndex].Add(long.Parse(match.Value));
                    }
                }
            }

            return maps;
        }
    }
}
