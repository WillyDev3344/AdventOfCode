using AdventOfCode.Utils;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day4
{
    class Day4 : Solution
    {
        protected override string ExecutePart1(List<string> inputContent)
        {
            int sum = 0;

            foreach (string line in inputContent)
            {
                List<int> winningNumbers = [];
                List<int> myNumbers = [];

                MatchCollection numbers = Regex.Matches(line, @" \d{1,}");

                for (int i =1; i < numbers.Count; i++)
                {
                    if (i < 11) winningNumbers.Add(int.Parse(numbers[i].Value));
                    else myNumbers.Add(int.Parse(numbers[i].Value));
                }

                HashSet<int> winningNumSet = new(winningNumbers);
                int cardScore = 0;

                foreach(int num in myNumbers)
                {
                    if (winningNumSet.Contains(num))
                    {
                        if (cardScore == 0) cardScore++;
                        else cardScore *= 2;
                    }
                }

                sum += cardScore;
            }

            return sum.ToString();
        }

        protected override string ExecutePart2(List<string> inputContent)
        {
            List<int> copies = new();
            for(int i = 0; i < inputContent.Count; i ++) copies.Add(1);

            for (int i = 0; i < inputContent.Count; i++)
            {
                string line = inputContent[i];
                List<int> winningNumbers = [];
                List<int> myNumbers = [];

                MatchCollection numbers = Regex.Matches(line, @" \d{1,}");

                for (int j = 1; j < numbers.Count; j++)
                {
                    if (j < 11) winningNumbers.Add(int.Parse(numbers[j].Value));
                    else myNumbers.Add(int.Parse(numbers[j].Value));
                }

                HashSet<int> winningNumSet = new(winningNumbers);
                int copyNum = 0;

                foreach (int num in myNumbers)
                {
                    if (winningNumSet.Contains(num))
                    {
                        copyNum++;
                    }
                }

                for(int j = 0; j < copyNum; j++)
                {
                    copies[i + 1 + j] += copies[i];
                }
            }

            return copies.Sum().ToString();
        }
    }
}